using CarDealerWebProject.Core.Contracts;
using CarDealerWebProject.Infrastructure.Data.Common;
using CarDealerWebProject.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CarDealerWebProject.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository repository;

        public UserService(IRepository repository)
        {
            this.repository = repository;
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
