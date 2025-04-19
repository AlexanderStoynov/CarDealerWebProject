using System.ComponentModel.DataAnnotations;
using static CarDealerWebProject.Core.Constants.MessageConstants;
using static CarDealerWebProject.Infrastructure.Constants.DataConstants;

namespace CarDealerWebProject.Core.Models.Admin
{
    public class CreateSellerFormModel
    {
        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(UserNameMaxLength, MinimumLength = UserNameMinLength, ErrorMessage = LengthMessage)]
        [Display(Name = "Full name")]
        public string UserFullName { get; set; } = null!;

        [Required(ErrorMessage = RequiredMessage)]
        [EmailAddress]
        [Display(Name = "User email")]
        public string UserEmail { get; set; } = null!;

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(PasswordMaxLength, MinimumLength = PasswordMinLength, ErrorMessage = LengthMessage)]
        [Display(Name = "User Password")]
        public string UserPassword { get; set; } = null!;

        
    }
}
