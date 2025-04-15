using CarDealerWebProject.Core.Contracts;
using CarDealerWebProject.Core.Models.Admin;
using CarDealerWebProject.Extensions;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarDealerWebProject.Controllers
{
    
    public class AdminController : BaseController
    {
        private readonly IUserService adminService;

        public AdminController(IUserService adminService)
        {
           this.adminService = adminService; 
        }

        //[HttpGet]
        //public async Task<IActionResult> CreateAgent()
        //{
           
        //}

        [HttpPost]
        public async Task<IActionResult> CreateAgent(CreateAgentFormModel model)
        {
            return RedirectToAction(nameof(VehicleController.Index), "Vehicle");
        }
    }
}
