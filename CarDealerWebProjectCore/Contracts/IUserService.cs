using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealerWebProject.Core.Contracts
{
    public interface IUserService
    {
        //Task<bool> ExistsByIdAsync(string userId);

        //Task<bool> UserWithPhoneNumberExists(string phoneNumber);

        Task CreateAsync(string userId, string name, string email, string password);
    }
}
