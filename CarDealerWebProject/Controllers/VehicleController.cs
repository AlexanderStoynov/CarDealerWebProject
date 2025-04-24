using CarDealerWebProject.Core.Contracts;
using CarDealerWebProject.Core.Models.Vehicle;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarDealerWebProject.Controllers
{
    public class VehicleController : Controller
    {
        private readonly IVehicleService vehicleService;

        private readonly IUserService userService;

        public VehicleController(IVehicleService vehicleService, IUserService userService)
        {
            this.vehicleService = vehicleService;
            this.userService = userService;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Index()
        {
            var model = new AllVehiclesQueryModel();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var model = new VehicleDetailsViewModel();

            return View(model);
        }

        [Authorize(Roles = "Admin, Seller")]
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new VehicleFormModel()
            {
                Categories = await vehicleService.AllCategoriesAsync()
            };

            return View(model);
        }

        [Authorize(Roles = "Admin, Seller")]
        [HttpPost]
        public async Task<IActionResult> Add(VehicleFormModel vehicleModel)
        {
            if (await vehicleService.CategoryExistsAsync(vehicleModel.CategoryId) == false)
            {
                ModelState.AddModelError(nameof(vehicleModel.CategoryId), "");
            }

            if(ModelState.IsValid == false)
            {
                vehicleModel.Categories = await vehicleService.AllCategoriesAsync();

                return View(vehicleModel);
            }

            int newVehicleId = await vehicleService.CreateAsync(vehicleModel);

            return RedirectToAction(nameof(Details), new { id = newVehicleId });
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var model = new VehicleFormModel();

            //return View(model);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, VehicleFormModel model)
        {
            return RedirectToAction(nameof(Details), new { id = id, });
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var model = new VehicleDetailsViewModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id, VehicleDetailsViewModel model)
        {
            return RedirectToAction(nameof(Index));
        }
    }
}
