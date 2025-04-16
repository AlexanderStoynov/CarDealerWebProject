using CarDealerWebProject.Attributes;
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
        private readonly IUserService userService;

        public AdminController(IUserService userService)
        {
           this.userService = userService; 
        }

        [HttpGet]
        [IsUser]
        public IActionResult CreateAgent()
        {
            var model = new CreateSellerFormModel();

            return View(model);
        }

        [HttpPost]
        [IsUser]
        public async Task<IActionResult> CreateSeller(CreateSellerFormModel model)
        {
            if (ModelState.IsValid == false) 
            { 
                return View(model);
            }

            await userService.CreateAsync(model.UserFullName);

            return RedirectToAction(nameof(VehicleController.Index), "Vehicle");
        }
    }
}
