using CarDealerWebProject.Attributes;
using CarDealerWebProject.Core.Contracts;
using CarDealerWebProject.Core.Models.Admin;
using CarDealerWebProject.Extensions;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using System.Text.Encodings.Web;
using System.Text;
using CarDealerWebProject.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace CarDealerWebProject.Controllers
{
    
    public class AdminController : BaseController
    {
        private readonly IUserService userService;
        private readonly UserManager<User> userManager;
        private readonly IUserStore<User> userStore;
        private readonly IUserEmailStore<User> emailStore;

        public AdminController(IUserService userService, 
            UserManager<User> userManager, 
            IUserStore<User> userStore)
        {
            this.userService = userService;
            this.userManager = userManager;
            this.userStore = userStore;
            this.emailStore = GetEmailStore();

        }

        [HttpGet]
        [IsUser]
        public IActionResult CreateSeller()
        {
            var model = new CreateSellerFormModel();

            return View(model);
        }

        [HttpPost]
        [IsUser()]
        public async Task<IActionResult> CreateSeller(CreateSellerFormModel model)
        {
            if (ModelState.IsValid == false) 
            {
                return View(model);
            }

            var seller = new User();

            await userStore.SetUserNameAsync(seller, model.UserEmail, CancellationToken.None);
            await emailStore.SetEmailAsync(seller, model.UserEmail, CancellationToken.None);
            seller.FullName = model.UserFullName;
            string sellerPassword = model.UserPassword; 

            var result = await userManager.CreateAsync(seller, sellerPassword);

            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(seller, "Seller");
            }

            else
            {
                throw new Exception($"Failed to create seller: {string.Join(", ", result.Errors.Select(e => e.Description))}");
            }

            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        private IUserEmailStore<User> GetEmailStore()
        {
            if (!userManager.SupportsUserEmail)
            {
                throw new NotSupportedException("The default UI requires a user store with email support.");
            }
            return (IUserEmailStore<User>)userStore;
        }
    }
}
