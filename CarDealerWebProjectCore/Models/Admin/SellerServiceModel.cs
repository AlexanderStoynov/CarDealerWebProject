using System.ComponentModel.DataAnnotations;
using static CarDealerWebProject.Core.Constants.MessageConstants;
using static CarDealerWebProject.Infrastructure.Constants.DataConstants;

namespace CarDealerWebProject.Core.Models.Admin
{
    public class SellerServiceModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(UserNameMaxLength, MinimumLength = UserNameMinLength, ErrorMessage = LengthMessage)]
        [Display(Name = "Full Name")]
        public string FullName { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
    }
}
