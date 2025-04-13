using CarDealerWebProject.Core.Contracts.Vehicle;
using CarDealerWebProject.Core.Models.Home;
using CarDealerWebProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CarDealerWebProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;
        private readonly IVehicleService vehicleService;

        public HomeController(ILogger<HomeController> logger,
            IVehicleService vehicleService)
        {
            this.logger = logger;
            this.vehicleService = vehicleService;
        }

        public async  Task<IActionResult> Index()
        {
            var model = await vehicleService.LastSixVehicles();

            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
