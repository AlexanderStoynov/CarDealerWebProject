using CarDealerWebProject.Core.Contracts;
using CarDealerWebProject.Core.Models.Admin;
using CarDealerWebProject.Infrastructure.Data.Common;
using CarDealerWebProject.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CarDealerWebProject.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository repository;
        private readonly UserManager<User> userManager;

        public UserService(IRepository repository, UserManager<User> userManager)
        {
            this.repository = repository;
            this.userManager = userManager;
        }

        public async Task<IEnumerable<SellerServiceModel>> AllAsync()
        {
            var users = await repository.AllReadOnly<User>().ToListAsync();
            var result = new List<SellerServiceModel>();

            foreach (var user in users)
            {
                if(!await userManager.IsInRoleAsync(user, "Admin"))
                {
                    result.Add(new SellerServiceModel
                    {
                        Email = user.Email,
                        FullName = user.FullName
                    });
                }
            }

            return result;
        }

        public async Task CreateAsync(string userName)
        {
            await repository.AddAsync(new User()
            {
                UserName = userName,
            });

            await repository.SaveChangesAsync();
        }

        public async Task<bool> ExistsByEmailAsync(string userEmail = null!)
        {
            return await repository.AllReadOnly<User>()
                .AnyAsync(u => u.Email == userEmail);
        }
    }
}
