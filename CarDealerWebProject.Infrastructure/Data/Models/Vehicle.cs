using CarDealerWebProject.Infrastructure.Data.Enums;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static CarDealerWebProject.Infrastructure.Constants.DataConstants;

namespace CarDealerWebProject.Infrastructure.Data.Models
{
    [Comment("Vehicle parameters")]
    public class Vehicle
    {
        [Key]
        [Comment("Vehicle identifier")]
        public int Id { get; set; }

        [Required]
        [StringLength(VehicleMakeMaxLength, MinimumLength = VehicleMakeMinLength)]
        [Comment("Vehicle maker name")]
        public required string Make { get; set; }

        [Required]
        [StringLength(VehicleModelMaxLength, MinimumLength = VehicleModelMinLength)]
        [Comment("Vehicle model")]
        public required string Model { get; set; }

        [Required]
        [StringLength(VehicleColorMaxLength, MinimumLength = VehicleColorMinLength)]
        [Comment("Vehicle color")]
        public required string Color { get; set; }

        [Comment("Vehicle transmission")]
        public Transmission Transmission { get; set; }

        [Comment("Vehicle manufacturing date")]
        public DateTime ManufacturingDate { get; set; }

        [Range(VehicleMotorHorsePowerMin, VehicleMotorHorsePowerMax)]
        [Comment("Motor horse power")]
        public int MotorHorsePower { get; set; }

        [Required]
        [Comment("Vehicle fuel type")]
        public FuelType Fuel { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        [Range(typeof(decimal), VehiclePriceMin, VehiclePriceMax, ConvertValueInInvariantCulture = true)]
        [Comment("Vehicle price")]
        public decimal Price { get; set; }

        [Range(VehicleMilageMin, VehicleMilageMax)]
        [Comment("Vehicle milage")]
        public int Milage { get; set; }

        [Required]
        [Comment("Vehicle images")]
        public List<string> VehicleImages { get; set; } = new List<string>();

        [StringLength(VehicleDescriptionMaxLength, MinimumLength = VehicleDescriptionMinLength)]
        [Comment("Vehicle description")]
        public required string Description { get; set; }

        [Required]
        [Comment("Category identifier")]
        public int CategoryId { get; set; }

        [Required]
        [Comment("If vehicle is sold")]
        public bool IsSold { get; set; } = false;

        public Category Category { get; set; } = null!;
 
    }


    //[Comment("Date vehicle is listed")]
    //public DateTime DateListed { get; set; }




    

    //    IsNew = false,
    //    SellerName = "John Doe",
    //    SellerPhone = "+359 123 456 789",
    //    Location = "Sofia",
    //    AirConditioning = true,
    //    Sunroof = false,
    //    NavigationSystem = true,
    //    LeatherSeats = true,
    //    ParkingSensors = true,
    //    BackupCamera = true,
    //    HeatedSeats = false,
    //    CruiseControl = true,
}
