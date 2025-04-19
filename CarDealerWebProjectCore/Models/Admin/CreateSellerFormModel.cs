using System.ComponentModel.DataAnnotations;
using static CarDealerWebProject.Core.Constants.MessageConstants;
using static CarDealerWebProject.Infrastructure.Constants.DataConstants;
using static CarDealerWebProject.Core.Constants.ModelDataConstants;

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
        [StringLength(SellerPasswordMaxLength, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = SellerPasswordMinLenght)]
        //[RegularExpression("[a-z]", ErrorMessage = "The {0} must contain at least one uppercase and lowercase letter, a number and a symbol")]
        //[DataType(DataType.Password)]
        [Display(Name = "User password")]
        public string UserPassword { get; set; } = null!;

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(SellerPasswordMaxLength, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = SellerPasswordMinLenght)]
        [Display(Name = "User confirm password")]
        //[RegularExpression(@"(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^a-zA-Z\d])", ErrorMessage = "The {0} must contain at least one uppercase and lowercase letter, a number and a symbol")]
        //[DataType(DataType.Password)]
        [Compare("UserPassword", ErrorMessage = "The password and confirmation password do not match.")]
        public string UserConfirmPassword { get; set; } = null!;

        
    }
}
