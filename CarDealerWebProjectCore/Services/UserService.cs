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

        public Task CreateAsync(string userId, string name, string email, string password)
        {
            throw new NotImplementedException();
        }

        //public Task<bool> ExistsByIdAsync(string userId)
        //{
        //    return repository.AllReadOnly<User>()
        //        .AnyAsync(a => a.UserId == userId);
        //}
    }
}
