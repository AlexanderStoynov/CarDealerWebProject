using CarDealerWebProject.Core.Models.Vehicle;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarDealerWebProject.Controllers
{
    public class VehicleController : Controller
    {
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

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(VehicleFormModel model)
        {
            return RedirectToAction(nameof(Details), new { id = 1 });
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var model = new VehicleFormModel();

            return View(model);
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
