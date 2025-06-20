using CarDealerWebProject.Infrastructure.Data.Enums;
using System.ComponentModel.DataAnnotations;
using static CarDealerWebProject.Core.Constants.MessageConstants;
using static CarDealerWebProject.Infrastructure.Constants.DataConstants;

namespace CarDealerWebProject.Core.Models.Vehicle
{
    public class VehicleDetailsServiceModel : VehicleServiceModel
    {
        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(VehicleColorMaxLength, MinimumLength = VehicleColorMinLength)]
        [Display(Name = "Color")]
        public string Color { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        [Display(Name = "Transmission")]
        public Transmission Transmission { get; set; }

        [Required(ErrorMessage = RequiredMessage)]
        [Display(Name = "Manufacturing date")]
        public DateTime ManufacturingDate { get; set; }

        [Required(ErrorMessage = RequiredMessage)]
        [Display(Name = "Fule type")]
        public FuelType Fuel { get; set; }

        [Required(ErrorMessage = RequiredMessage)]
        [Range(VehicleMilageMin, VehicleMilageMax)]
        [Display(Name = "Milage")]
        public int Milage { get; set; }

        [StringLength(VehicleDescriptionMaxLength, MinimumLength = VehicleDescriptionMinLength)]
        [Display(Name = "Description")]
        public string Description { get; set; } = null!;

    }
}
