using CarDealerWebProject.Core.Contracts;
using CarDealerWebProject.Core.Models.Admin;
using CarDealerWebProject.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using static CarDealerWebProject.Core.Constants.AdminConstants;

namespace CarDealerWebProject.Areas.Admin.Controllers
{
    [Area(AdminAreaName)]
    [Authorize(Roles = AdminRole)]
    public class SellerManagementController : AdminBaseController
    {
        private readonly IUserService userService;
        private readonly UserManager<User> userManager;
        private readonly IUserStore<User> userStore;
        private readonly IUserEmailStore<User> emailStore;

        public SellerManagementController(IUserService userService,
            UserManager<User> userManager,
            IUserStore<User> userStore)
        {
            this.userService = userService;
            this.userManager = userManager;
            this.userStore = userStore;
            this.emailStore = GetEmailStore();

        }

        [HttpGet]
        public IActionResult CreateSeller()
        {
            var model = new CreateSellerFormModel();

            return View(model);
        }

        [HttpPost]
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

            return RedirectToAction(nameof(HomeController.DashBoard), "Dashboard");
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
