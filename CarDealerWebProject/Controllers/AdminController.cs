using CarDealerWebProject.Core.Models.Admin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarDealerWebProject.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> CreateAgent()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAgent(CreateAgentFormModel model)
        {
            return RedirectToAction(nameof(VehicleController.Index), "Vehicle");
        }
    }
}
