using CarDealerWebProject.Core.Contracts.Models;
using CarDealerWebProject.Infrastructure.Data.Enums;
using CarDealerWebProject.Infrastructure.Data.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static CarDealerWebProject.Core.Constants.MessageConstants;
using static CarDealerWebProject.Infrastructure.Constants.DataConstants;

namespace CarDealerWebProject.Core.Models.Vehicle.SeviceModels
{
    public class VehicleDetailsServiceModel : IVehicleModel
    {
        [Required(ErrorMessage = RequiredMessage)]
        [Display(Name = "Vehicle ID")]
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
        [StringLength(VehicleColorMaxLength, MinimumLength = VehicleColorMinLength)]
        [Display(Name = "Color")]
        public string Color { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        [Display(Name = "Transmission")]
        public Transmission Transmission { get; set; }

        [Required(ErrorMessage = RequiredMessage)]
        [Display(Name = "Manufacturing date")]
        public DateOnly ManufacturingDate { get; set; }

        [Required(ErrorMessage = RequiredMessage)]
        [Column(TypeName = "decimal(18,2)")]
        [Range(typeof(decimal), VehiclePriceMin, VehiclePriceMax, ConvertValueInInvariantCulture = true,
            ErrorMessage = "The vehicle price must be a positive number and between {1} and {2} euro")]
        [Display(Name = "Price")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = RequiredMessage)]
        [Range(VehicleMileageMin, VehicleMileageMax)]
        [Display(Name = "Mileage")]
        public int Mileage { get; set; }

        [Required(ErrorMessage = RequiredMessage)]
        [DisplayName("Vehicle motors")]
        public List<Motor> Motors { get; set; } = new List<Motor>();

        [StringLength(VehicleDescriptionMaxLength, MinimumLength = VehicleDescriptionMinLength)]
        [Display(Name = "Description")]
        public string Description { get; set; } = null!;

        [Required(ErrorMessage = RequiredMessage)]
        [Display(Name = "Vehicle Images")]
        public List<string> VehicleImages { get; set; } = new List<string>();

        [Required(ErrorMessage = RequiredMessage)]
        [Display(Name = "If vehicle is sold")]
        public bool IsSold { get; set; } = false;

    }
}
