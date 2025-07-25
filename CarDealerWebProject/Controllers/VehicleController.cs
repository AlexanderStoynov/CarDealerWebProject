﻿using CarDealerWebProject.Core.Contracts;
using CarDealerWebProject.Core.Extensions;
using CarDealerWebProject.Core.Models.Vehicle;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarDealerWebProject.Controllers
{
    public class VehicleController : Controller
    {
        private readonly IVehicleService vehicleService;

        public VehicleController(IVehicleService vehicleService)
        {
            this.vehicleService = vehicleService;   
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> All([FromQuery]AllVehiclesQueryModel model)
        {
            var vehicles = await vehicleService.AllAsync(
                model.Sorting,
                model.CurrentPage,
                model.VehiclesPerPage);

            model.TotalVehiclesCount = vehicles.TotalVehicleCount;
            model.Vehicles = vehicles.Vehicles;

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id, string information)
        {
            if(await vehicleService.ExistsAsync(id) == false)
            {
                return BadRequest();
            }

            var model = await vehicleService.VehicleDetailsByIdAsync(id);
            
            if (information != model.GetInformation())
            {
                return BadRequest(information);
            }

            return View(model);
        }

        [Authorize(Roles = "Admin, Seller")]
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new VehicleFormModel();
            

            return View(model);
        }

        [Authorize(Roles = "Admin, Seller")]
        [HttpPost]
        public async Task<IActionResult> Add(VehicleFormModel vehicleModel)
        {

            if(ModelState.IsValid == false)
            {
                return View(vehicleModel);
            }

            int newVehicleId = await vehicleService.CreateAsync(vehicleModel);

            return RedirectToAction(nameof(Details), new { id = newVehicleId, information = vehicleModel.GetInformation()});
        }

        [Authorize(Roles = "Admin, Seller")]
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if(await vehicleService.ExistsAsync(id) == false)
            {
                return BadRequest();
            }

            var model = await vehicleService.GetVehicleFormModelByIdAsync(id);

            return View(model);
        }

        [Authorize(Roles = "Admin, Seller")]
        [HttpPost]
        public async Task<IActionResult> EditAsync(int id, VehicleFormModel model)
        {
            if (await vehicleService.ExistsAsync(id) == false)
            {
                return BadRequest();
            }

            if (ModelState.IsValid == false)
            {
                return View(model);
            }

            await vehicleService.EditAsync(id, model);

            return RedirectToAction(nameof(Details), new { id, information = model.GetInformation() });
        }

        [Authorize(Roles = "Admin, Seller")]
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {

            if(await vehicleService.ExistsAsync(id) == false)
            {
                return BadRequest();
            }

            var vehicle = await vehicleService.VehicleDetailsByIdAsync(id);

            var model = new VehicleDetailsViewModel()
            {
                Id = id,
                Make = vehicle.Make,
                Model = vehicle.Model,
                VehicleImage = vehicle.VehicleImages[0],
            }; 

            return View(model);
        }

        [Authorize(Roles = "Admin, Seller")]
        [HttpPost]
        public async Task<IActionResult> Delete(VehicleDetailsViewModel model)
        {
            if (await vehicleService.ExistsAsync(model.Id) == false)
            {
                return BadRequest();
            }

            await vehicleService.DeleteAsync(model.Id);

            return RedirectToAction(nameof(All));
        }
    }
}
