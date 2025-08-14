using CarDealerWebProject.Core.Constants;
using CarDealerWebProject.Core.Contracts;
using CarDealerWebProject.Core.Extensions;
using CarDealerWebProject.Core.Models.Vehicle;
using CarDealerWebProject.Core.Models.Vehicle.FormModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using static CarDealerWebProject.Core.Constants.VehicleConstants;


namespace CarDealerWebProject.Controllers
{
    public class VehicleController : Controller
    {
        private readonly IVehicleService vehicleService;
        private readonly IMemoryCache memoryCache;

        public VehicleController(IVehicleService vehicleService, IMemoryCache memoryCache)
        {
            this.vehicleService = vehicleService;
            this.memoryCache = memoryCache;
        }

        //Tova e metoda dime Vuv Project Core imam factories tam trqbva da go napravq da
        //sloja metoda v CreateVehicleAsync i da trugne.
        [Authorize(Roles = "Admin, Seller")]
        [HttpGet]
        public async Task<IActionResult> AddVehicle()
        {
            var model = new VehicleFormModel();

            return await Task.FromResult(View(model));
        }

        [Authorize(Roles = "Admin, Seller")]
        [HttpPost]
        public async Task<IActionResult> AddVehicle(VehicleFormModel vehicleModel)
        {
            if (ModelState.IsValid == false)
            {
                return View(vehicleModel);
            }

            int newVehicleId = await vehicleService.CreateVehicleAsync(vehicleModel);

            TempData[MessageConstants.UserMessageSuccess] = VehicleAddedSuccessfullyMessage;

            return RedirectToAction(nameof(VehicleDetails), new { id = newVehicleId, information = vehicleModel.GetInformation() });
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> AllVehicles([FromQuery] AllVehiclesQueryModel model)
        {
            if (ModelState.IsValid == false)
            {
                return View(model);
            }

            string cacheKey = $"{VehiclesCacheKey}_{model.Sorting}_{model.CurrentPage}_{model.VehiclesPerPage}";

            var cacheModel = memoryCache.Get<AllVehiclesQueryModel>(cacheKey);

            if (cacheModel == null)
            {
                var vehicles = await vehicleService.AllVehiclesAsync(
                model.Sorting,
                model.CurrentPage,
                model.VehiclesPerPage);

                model.TotalVehiclesCount = vehicles.TotalVehicleCount;
                model.Vehicles = vehicles.Vehicles;

                var cacheOptions = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromMinutes(1));

                memoryCache.Set(cacheKey, model, cacheOptions);
            }

            return View(model);
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> VehicleDetails(int id, string information)
        {
            if (await vehicleService.VehicleExistsByIdAsync(id) == false)
            {
                TempData[MessageConstants.UserMessageError] = VehicleNotFoundMessage;
                return RedirectToAction(nameof(AllVehicles));
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
        public async Task<IActionResult> EditVehicle(int id)
        {
            if (await vehicleService.VehicleExistsByIdAsync(id) == false)
            {
                TempData[MessageConstants.UserMessageError] = VehicleNotFoundMessage;
                return RedirectToAction(nameof(AllVehicles));
            }

            var model = await vehicleService.GetVehicleFormModelByIdAsync(id);

            return View(model);
        }

        [Authorize(Roles = "Admin, Seller")]
        [HttpPost]
        public async Task<IActionResult> EditVehicle(int id, VehicleFormModel vehicleModel)
        {
            if (await vehicleService.VehicleExistsByIdAsync(id) == false)
            {
                TempData[MessageConstants.UserMessageError] = VehicleNotFoundMessage;
                return RedirectToAction(nameof(AllVehicles));
            }

            if (ModelState.IsValid == false)
            {
                return View(vehicleModel);
            }

            await vehicleService.EditVehicleAsync(id, vehicleModel);

            TempData[MessageConstants.UserMessageSuccess] = VehicleEditedSuccessfullyMessage;

            return RedirectToAction(nameof(VehicleDetails), new { id, information = vehicleModel.GetInformation() });
        }

        [Authorize(Roles = "Admin, Seller")]
        [HttpGet]
        public async Task<IActionResult> DeleteVehicle(int id)
        {

            if (await vehicleService.VehicleExistsByIdAsync(id) == false)
            {
                TempData[MessageConstants.UserMessageError] = VehicleNotFoundMessage;
                return RedirectToAction(nameof(AllVehicles));
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
        public async Task<IActionResult> DeleteVehicle(VehicleDetailsViewModel vehicleModel)
        {
            if (await vehicleService.VehicleExistsByIdAsync(vehicleModel.Id) == false)
            {
                TempData[MessageConstants.UserMessageError] = VehicleNotFoundMessage;
                return RedirectToAction(nameof(AllVehicles));
            }

            await vehicleService.DeleteVehicleAsync(vehicleModel.Id);

            TempData[MessageConstants.UserMessageSuccess] = VehicleDeletedSuccessfullyMessage;

            return RedirectToAction(nameof(AllVehicles));
        }
    }
}
