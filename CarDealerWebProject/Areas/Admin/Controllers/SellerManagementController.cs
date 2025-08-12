using CarDealerWebProject.Core.Constants;
using CarDealerWebProject.Core.Contracts;
using CarDealerWebProject.Core.Models.Admin;
using CarDealerWebProject.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using static CarDealerWebProject.Core.Constants.AdminConstants;


namespace CarDealerWebProject.Areas.Admin.Controllers
{
    [Area(AdminAreaName)]
    [Authorize(Roles = AdminRole)]
    public class SellerManagementController : AdminBaseController
    {
        private readonly ISellerService sellerService;
        private readonly IMemoryCache memoryCache;

        public SellerManagementController(ISellerService sellerService,
            IUserStore<User> userStore,
            IMemoryCache memoryCache)
        {
            this.sellerService = sellerService;
            this.memoryCache = memoryCache;

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
            if (await sellerService.SellerExistsByEmailAsync(model.UserEmail))
            {
                ModelState.AddModelError(nameof(model.UserEmail), SellerEmailExistsError);
            }

            if (ModelState.IsValid == false)
            {
                return View(model);
            }

            await sellerService.CreateSellerAsync(model);

            TempData[MessageConstants.UserMessageSuccess] = "Seller created successfully!";

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> AllSellers()
        {
            var model = memoryCache.Get<IEnumerable<SellerServiceModel>>(SellersCacheKey);

            if (model == null || model.Any() == false)
            {
                model = await sellerService.AllSellersAsync();
                var cacheOptions = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromMinutes(3));

                memoryCache.Set(SellersCacheKey, model, cacheOptions);
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> EditSeller(Guid id)
        {
            if (await sellerService.ExistsByIdAsync(id) == false)
            {
                TempData[MessageConstants.UserMessageError] = "Seller not found.";
                return RedirectToAction(nameof(AllSellers));
            }

            var model = await sellerService.GetSellerServiceModelByIdAsync(id);

            return View (model);
        }

        [HttpPost]
        public async Task<IActionResult> EditSeller(Guid id, SellerServiceModel model)
        {
            if (await sellerService.ExistsByIdAsync(id) == false)
            {
                TempData[MessageConstants.UserMessageError] = "Seller not found.";
                return RedirectToAction(nameof(AllSellers));
            }

            if (ModelState.IsValid == false)
            {
                return View(model);
            }

            await sellerService.EditSellerAsync(id, model);

            TempData[MessageConstants.UserMessageSuccess] = "Seller edited successfully!";

            return RedirectToAction(nameof(AllSellers));
        }

        [HttpGet]
        public async Task<IActionResult> DeleteSeller(Guid id)
        {
            if (await sellerService.ExistsByIdAsync(id) == false)
            {
                TempData[MessageConstants.UserMessageError] = "Seller not found.";
                return RedirectToAction(nameof(AllSellers));
            }

            var model = await sellerService.GetSellerServiceModelByIdAsync(id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteSeller(SellerServiceModel model)
        {
            if (await sellerService.ExistsByIdAsync(model.Id) == false)
            {
                TempData[MessageConstants.UserMessageError] = "Seller not found.";
                return RedirectToAction(nameof(AllSellers));
            }

            if (ModelState.IsValid == false)
            {
                return View(model);
            }

            await sellerService.DeleteSellerAsync(model.Id);

            TempData[MessageConstants.UserMessageSuccess] = "Seller deleted successfully!";

            return RedirectToAction(nameof(AllSellers));
        }
    }
}
