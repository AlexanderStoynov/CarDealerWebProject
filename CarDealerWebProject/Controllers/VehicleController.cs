using CarDealerWebProject.Core.Constants;
using CarDealerWebProject.Core.Contracts;
using CarDealerWebProject.Core.Extensions;
using CarDealerWebProject.Core.Models.Vehicle;
using CarDealerWebProject.Core.Models.Vehicle.FormModels;
using CarDealerWebProject.Infrastructure.Data.Enums;
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
                VehicleTypes.PetrolCar => new PetrolCarFormModel(),
                VehicleTypes.HybridCar => new HybridCarFormModel(),
                VehicleTypes.ElectricCar => new ElectricCarFormModel(),
                VehicleTypes.Motorcycle => new MotorcycleFormModel(),
                _ => throw new ArgumentException("Unsupported vehicle type")
            };

            return await Task.FromResult(View(model));
        }

        [Authorize(Roles = "Admin, Seller")]
        [HttpPost]
        public async Task<IActionResult> AddVehicle()
        {
            var typeString = Request.Form["VehicleType"];
            if (!Enum.TryParse<VehicleTypes>(typeString, ignoreCase: true, out var vehicleType))
            {
                ModelState.AddModelError("", "Invalid vehicle type.");
                return View();
            }

            // Depending on type, bind the correct concrete model
            VehicleFormModel model = vehicleType switch
            {
                VehicleTypes.PetrolCar => new PetrolCarFormModel(),
                VehicleTypes.HybridCar => new HybridCarFormModel(),
                VehicleTypes.ElectricCar => new ElectricCarFormModel(),
                VehicleTypes.Motorcycle => new MotorcycleFormModel(),
                _ => throw new ArgumentException("Unsupported vehicle type")
            };

            // Try to update model from form values
            if (!await TryUpdateModelAsync(model))
            {
                return View(model);
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            int newVehicleId = await vehicleService.CreateVehicleAsync(model);
            return RedirectToAction(nameof(VehicleDetails), new { id = newVehicleId, information = model.GetInformation() });
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
