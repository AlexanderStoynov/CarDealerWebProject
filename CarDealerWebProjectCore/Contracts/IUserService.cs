﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealerWebProject.Core.Contracts
{
    public interface IUserService
    {
        Task<bool> ExistsByEmailAsync(string userEmail);

        //Task CreateAsync(string userName);
    }
}
