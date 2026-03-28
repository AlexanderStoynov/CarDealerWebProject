using CarDealerWebProject.Core.Constants;
using CarDealerWebProject.Core.Contracts.Services;
using CarDealerWebProject.Core.Extensions;
using CarDealerWebProject.Core.Factories;
using CarDealerWebProject.Core.Models.Vehicle;
using CarDealerWebProject.Core.Models.Vehicle.FormModels;
using CarDealerWebProject.Core.Models.Vehicle.SeviceModels;
using CarDealerWebProject.Infrastructure.Data.Enums;
using CarDealerWebProject.Infrastructure.Data.Models;
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

        [Authorize(Roles = "Admin, Seller")]
        [HttpGet]
        public IActionResult SelectVehicleCreationType()
        {
            return View();
        }

        [Authorize(Roles = "Admin, Seller")]
        [HttpGet]
        public async Task<IActionResult> AddVehicle(VehicleTypes type)
        {
            VehicleFormModel model = type switch
            {
                VehicleTypes.Car => new CarFormModel(),
                VehicleTypes.Motorcycle => new MotorcycleFormModel(),
                _ => throw new ArgumentException("Unsupported vehicle type")
            };

            model.VehicleType = type;

            return await Task.FromResult(View(model));
        }

        [Authorize(Roles = "Admin, Seller")]
        [HttpPost]
        public async Task<IActionResult> AddCar(CarFormModel vehicleModel)
        {
            if ((ValidateVehicleType(vehicleModel.VehicleType, vehicleModel) as ViewResult) is ViewResult vr) return vr;

            if (!ModelState.IsValid)
                return View("AddVehicle", vehicleModel);

            Vehicle newVehicle;
            try
            {
                newVehicle = VehicleFactory.Create(vehicleModel);
            }
            catch (ArgumentException exception)
            {
                ModelState.AddModelError("", exception.Message);
                return View("AddVehicle",vehicleModel);
            }
            int newVehicleId = await vehicleService.CreateVehicleAsync(newVehicle);

            return RedirectToAction(nameof(VehicleDetails), new { id = newVehicleId, information = vehicleModel.GetInformation()});
        }

        [Authorize(Roles = "Admin, Seller")]
        [HttpPost]
        public async Task<IActionResult> AddMotorcycle(MotorcycleFormModel vehicleModel)
        {
            if ((ValidateVehicleType(vehicleModel.VehicleType, vehicleModel) as ViewResult) is ViewResult vr) return vr;

            if (!ModelState.IsValid)
                return View("AddVehicle",vehicleModel);

            Vehicle newVehicle;
            try
            {
                newVehicle = VehicleFactory.Create(vehicleModel);
            }
            catch (ArgumentException exception)
            {
                ModelState.AddModelError("", exception.Message);
                return View("AddVehicle", vehicleModel);
            }

            int newVehicleId = await vehicleService.CreateVehicleAsync(newVehicle);

            return RedirectToAction(nameof(VehicleDetails), new { id = newVehicleId, information = vehicleModel.GetInformation() });
        }

        private IActionResult ValidateVehicleType(VehicleTypes type, VehicleFormModel model)
        {
            if (!Enum.IsDefined(typeof(VehicleTypes), type))
            {
                ModelState.AddModelError("", "Unsupported vehicle type.");
                return View(model);
            }

            return new EmptyResult();
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
                    .SetAbsoluteExpiration(TimeSpan.FromSeconds(2));

                memoryCache.Set(cacheKey, model, cacheOptions);
            }

            else
            {
                model = cacheModel;
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
        ////////////////////////////////////////////////////////////////////

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

            return RedirectToAction(nameof(VehicleDetails), new { id, information = vehicleModel.GetInformation()});
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

            var vehicle = await vehicleService.VehiclePreviewByIdAsync(id);

            var model = new VehiclePreviewServiceModel()
            {
                Id = id,
                Make = vehicle.Make,
                Model = vehicle.Model,
                Price = vehicle.Price,
                HorsePower = vehicle.HorsePower,
                VehicleType = vehicle.VehicleType,
                FirstVehicleImage = vehicle.FirstVehicleImage
            };

            return View(model);
        }

        [Authorize(Roles = "Admin, Seller")]
        [HttpPost]
        public async Task<IActionResult> DeleteVehicle(VehiclePreviewServiceModel vehicleModel)
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
