using CarDealerWebProject.Core.Contracts;
using CarDealerWebProject.Core.Models.Admin;
using CarDealerWebProject.Infrastructure.Data.Common;
using CarDealerWebProject.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using static CarDealerWebProject.Core.Constants.AdminConstants;


namespace CarDealerWebProject.Core.Services
{
    public class SellerService : ISellerService
    {
        private readonly IRepository repository;
        private readonly UserManager<User> userManager;
        private readonly IUserStore<User> userStore;

        public SellerService(IRepository repository, UserManager<User> userManager, IUserStore<User> userStore)
        {
            this.repository = repository;
            this.userManager = userManager;
            this.userStore = userStore;
        }

        public async Task<IEnumerable<SellerServiceModel>> AllSellersAsync()
        {
            var sellers = await repository.AllReadOnly<User>().ToListAsync();
            var result = new List<SellerServiceModel>();

            foreach (var user in sellers)
            {
                result.Add(new SellerServiceModel
                {
                    Id = user.Id,
                    Email = user.Email,
                    FullName = user.FullName
                });
            }

            return result;
        }

        public async Task CreateSellerAsync(CreateSellerFormModel model)
        {
            var seller = new User();

            await userStore.SetUserNameAsync(seller, model.UserEmail, CancellationToken.None);
            seller.FullName = model.UserFullName;
            seller.Email = model.UserEmail;
            string sellerPassword = model.UserPassword;
            string confirmedPassword = model.UserConfirmPassword;

            var result = await userManager.CreateAsync(seller, sellerPassword);

            if (sellerPassword != confirmedPassword)
            {
                throw new Exception(PasswordsDoNotMatchError);
            }

            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(seller, "Seller");
            }

            else
            {
                throw new Exception($"{FailedToCreateSellerError}{string.Join(", ", result.Errors.Select(e => e.Description))}");
            }
        }

        public async Task<bool> SellerExistsByEmailAsync(string userEmail = null!)
        {
            return await repository.AllReadOnly<User>()
                .AnyAsync(u => u.Email == userEmail);
        }

        public async Task<bool> SellerExistsByIdAsync(Guid id)
        {
            return await repository.AllReadOnly<User>()
                 .AnyAsync(u => u.Id == id);
        }

        public async Task<Guid> GetSellerIdAsync(Guid id)
        {
            return await repository.AllReadOnly<User>()
                .Where(u => u.Id == id)
                .Select(u => u.Id)
                .FirstOrDefaultAsync();
        }

        public async Task<SellerServiceModel?> GetSellerServiceModelByIdAsync(Guid id)
        {
            var seller = await repository.AllReadOnly<User>()
                .Where(u => u.Id == id)
                .Select(u => new SellerServiceModel()
                {
                    FullName = u.FullName,
                    Email = u.Email,
                    Id = u.Id
                })
                .FirstOrDefaultAsync();

            return seller;
        }

        public async Task EditSellerAsync(Guid id, SellerServiceModel model)
        {
            var seller = await repository.GetByIdAsync<User>(id);

            if (seller != null)
            {
                seller.Email = model.Email;
                seller.FullName = model.FullName;

                await repository.SaveChangesAsync();
            }

            else
            {
                throw new Exception(UserNotFoundError);
            }
        }

        public async Task DeleteSellerAsync(Guid id)
        {

            var seller = await userManager.FindByIdAsync(id.ToString());

            if (seller == null)
            {
                throw new Exception(UserNotFoundError);
            }

            if (await userManager.IsInRoleAsync(seller, "Admin") == true)
            {
                throw new UnauthorizedAccessException(AdminCantBeRemovedError);
            }

            await repository.DeleteAsync<User>(id);

            await repository.SaveChangesAsync();
        }
    }
}
