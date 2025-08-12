using CarDealerWebProject.Core.Constants;
using CarDealerWebProject.Core.Contracts;
using CarDealerWebProject.Core.Models.Admin;
using CarDealerWebProject.Infrastructure.Data.Common;
using CarDealerWebProject.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


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
            var users = await repository.AllReadOnly<User>().ToListAsync();
            var result = new List<SellerServiceModel>();

            foreach (var user in users)
            {
                if(!await userManager.IsInRoleAsync(user, "Admin"))
                {
                    result.Add(new SellerServiceModel
                    {
                        Id = user.Id,
                        Email = user.Email,
                        FullName = user.FullName
                    });
                }
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
                throw new Exception("Passwords do not match");
            }

            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(seller, "Seller");
            }

            else
            {
                throw new Exception($"Failed to create seller: {string.Join(", ", result.Errors.Select(e => e.Description))}");
            }
        }

        public async Task<bool> ExistsByEmailAsync(string userEmail = null!)
        {
            return await repository.AllReadOnly<User>()
                .AnyAsync(u => u.Email == userEmail);
        }

        public async Task<bool> SellerExistsByIdAsync(Guid userId)
        {
            return await repository.AllReadOnly<User>()
                 .AnyAsync(u => u.Id == userId);
        }

        public async Task<Guid> GetSellerIdAsync(Guid userId)
        {
            return await repository.AllReadOnly<User>()
                .Where(u => u.Id == userId)
                .Select(u => u.Id)
                .FirstOrDefaultAsync();
        }

        public async Task<SellerServiceModel?> GetSellerServiceModelByIdAsync(Guid userId)
        {
            var seller = await repository.AllReadOnly<User>()
                .Where(u => u.Id == userId)
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
                throw new Exception("User not found");
            }
        }

        public async Task DeleteSellerAsync(Guid sellerId)
        {
           
            var user = await userManager.FindByIdAsync(sellerId.ToString());

            if (user == null)
            {
                throw new Exception("User not found");
            }

            if (await userManager.IsInRoleAsync(user, "Admin") == true)
            {
                throw new UnauthorizedAccessException("Admin cant be removed");
            }

            await repository.DeleteAsync<User>(sellerId);

            await repository.SaveChangesAsync();
        }
    }
}
