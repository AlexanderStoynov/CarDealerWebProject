using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CarDealerWebProject.Infrastructure.Data.Models
{
    public class User : IdentityUser
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


        [Required]
        [Comment("User name")]
        public string FullName { get; set; } = string.Empty;

    }
}
