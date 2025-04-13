using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealerWebProject.Infrastructure.Identity
{
    public class ApplicationUser : IdentityUser
    {
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address format")]
        public override string? Email
        {
            get => base.Email!;
            set
            {
                base.Email = value;
                base.UserName = value;
            }
        }

        public override string? UserName
        {
            get => base.UserName;
            set => base.UserName = value ?? base.Email;
        }


    }
}
