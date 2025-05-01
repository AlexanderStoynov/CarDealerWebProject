using CarDealerWebProject.Infrastructure.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static CarDealerWebProject.Core.Constants.MessageConstants;
using static CarDealerWebProject.Infrastructure.Constants.DataConstants;

namespace CarDealerWebProject.Core.Models.Vehicle
{
    public class VehicleFormModel
    {
        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(VehicleMakeMaxLength, MinimumLength = VehicleMakeMinLength, ErrorMessage = LengthMessage)]
        [Display(Name = "Make")]
        public  string Make { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(VehicleModelMaxLength, MinimumLength = VehicleModelMinLength, ErrorMessage = LengthMessage)]
        [Display(Name = "Model")]
        public  string Model { get; set; } = string.Empty;

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
        [Range(VehicleMotorHorsePowerMin, VehicleMotorHorsePowerMax)]
        [Display(Name = "Horse Power")]
        public int MotorHorsePower { get; set; }

        [Required(ErrorMessage = RequiredMessage)]
        [Display(Name = "Fule type")]
        public FuelType Fuel { get; set; }

        [Required(ErrorMessage = RequiredMessage)]
        [Column(TypeName = "decimal(18,2)")]
        [Range(typeof(decimal), VehiclePriceMin, VehiclePriceMax, ConvertValueInInvariantCulture = true, 
            ErrorMessage = "The vehicle price must be a positive number and between {1} and {2} euro")]
        [Display(Name = "Price")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = RequiredMessage)]
        [Range(VehicleMilageMin, VehicleMilageMax)]
        [Display(Name = "Milage")]
        public int Milage { get; set; }

        [StringLength(VehicleDescriptionMaxLength, MinimumLength = VehicleDescriptionMinLength)]
        [Display(Name = "Description")]
        public string Description { get; set; } = string.Empty; 

        [Required(ErrorMessage = RequiredMessage)]
        [Display(Name = "Images")]
        public List<string> VehicleImages { get; set; } = new List<string>();

        [Required(ErrorMessage = RequiredMessage)]
        [Display(Name = "Select vehicle type")]
        public VehicleTypes SelectedType { get; set; }


        public ElectricCarFormModel? ElectricCarProperties { get; set; }
        public PetrolCarFormModel? PetrolCarProperties { get; set; }
        public MotorcycleFormModel? MotorcycleProperties { get; set; }
        public HybridCarFormModel? HybridCarProperties { get; set; }

    }
}
