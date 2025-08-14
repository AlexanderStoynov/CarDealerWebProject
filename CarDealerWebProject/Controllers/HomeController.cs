using CarDealerWebProject.Core.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarDealerWebProject.Controllers
{
    [AllowAnonymous]
    public class HomeController : BaseController
    {
        private readonly IVehicleService vehicleService;

        public HomeController(IVehicleService vehicleService)
        {
            this.vehicleService = vehicleService;
        }

        
        [HttpGet]
        public async  Task<IActionResult> Index()
        {
            var model = await vehicleService.LastSixVehiclesAsync();

            return View(model);
        }

        [HttpGet]
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
