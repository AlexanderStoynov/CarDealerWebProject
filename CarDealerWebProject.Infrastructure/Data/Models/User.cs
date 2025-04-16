using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using static CarDealerWebProject.Infrastructure.Constants.DataConstants;

namespace CarDealerWebProject.Infrastructure.Data.Models
{
    public class User : IdentityUser
    {
        [Required]
        [AllowNull]
        [EmailAddress(ErrorMessage = "Invalid email address format")]
        public override string Email
        {
            get => base.Email!;
            set
            {
                base.Email = value;
                base.UserName = value;
            }
        }

        [AllowNull]
        public override string UserName
        {
            get => base.UserName!;
            set => base.UserName = base.Email!;
        }


        [Required]
        [MaxLength(UserNameMaxLength)]
        [MinLength(UserNameMinLength)]
        [Comment("User name")]
        public string FullName { get; set; } = string.Empty;

    }
}
