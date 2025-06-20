using System.ComponentModel.DataAnnotations;
using static CarDealerWebProject.Infrastructure.Constants.DataConstants;
using static CarDealerWebProject.Core.Constants.MessageConstants;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarDealerWebProject.Core.Models.Vehicle
{
    public class VehicleServiceModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(VehicleMakeMaxLength, MinimumLength = VehicleMakeMinLength, ErrorMessage = LengthMessage)]
        [Display(Name = "Make")]
        public string Make { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(VehicleModelMaxLength, MinimumLength = VehicleModelMinLength, ErrorMessage = LengthMessage)]
        [Display(Name = "Model")]
        public string Model { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        [Column(TypeName = "decimal(18,2)")]
        [Range(typeof(decimal), VehiclePriceMin, VehiclePriceMax, ConvertValueInInvariantCulture = true,
            ErrorMessage = "The vehicle price must be a positive number and between {1} and {2} euro")]
        [Display(Name = "Price")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = RequiredMessage)]
        [Range(VehicleMotorHorsePowerMin, VehicleMotorHorsePowerMax)]
        [Display(Name = "Horse Power")]
        public int MotorHorsePower { get; set; }

        [Required(ErrorMessage = RequiredMessage)]
        [Display(Name = "Image URL")]
        public List<string> VehicleImages { get; set; } = new List<string>();

        
    }
}