using CarDealerWebProject.Core.Contracts;
using CarDealerWebProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CarDealerWebProject.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> logger;
        private readonly IVehicleService vehicleService;

        public HomeController(ILogger<HomeController> logger,
            IVehicleService vehicleService)
        {
            this.logger = logger;
            this.vehicleService = vehicleService;
        }

        [AllowAnonymous]
        public async  Task<IActionResult> Index()
        {
            var model = await vehicleService.LastSixVehiclesAsync();

            return View(model);
        }

        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(int statusCode)
        {
            if(statusCode == 400)
            {
                return View("Error400");
            }


            if (statusCode == 401)
            {
                return View("Error401");
            }

            return View();
        }
    }
}
