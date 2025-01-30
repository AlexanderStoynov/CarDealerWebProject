using CarDealerWebProject.Infrastructure.Data.Enums;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
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
        [MaxLength(VehicleMakeMaxLength)]
        [Comment("Vehicle maker name")]
        public required string Make { get; set; }

        [Required]
        [MaxLength(VehicleModelMaxLength)]
        [Comment("Vehicle model")]
        public required string Model { get; set; }

        [Comment("Vehicle manufacturing date")]
        public DateTime ManufacturingDate { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        [Range(typeof(decimal), VehiclePriceMin, VehiclePriceMax, ConvertValueInInvariantCulture = true)]
        [Comment("Vehicle price")]
        public decimal Price { get; set; }

        [Required]
        [Comment("Vehicle fuel type")]
        public FuelType Fuel { get; set; }

        [Range(VehicleMilageMin, VehicleMilageMax)]
        [Comment("Vehicle milage")]
        public int Milage { get; set; }

        [Range(VehicleMotorHorsePowerMin, VehicleMotorHorsePowerMax)]
        [Comment("Motor horse power")]
        public int MotorHorsePower { get; set; }

        [Range(VehicleEngineCapacityMin, VehicleEngineCapacityMax)]
        [Comment("Engine capacity")]
        public int EngineCapacity { get; set; }

        [Comment("Vehicle transmission")]
        public Transmission Transmission { get; set; }

        [MaxLength(VehicleDescriptionMaxLength)]
        [Comment("Vehicle description")]
        public string Description { get; set; } = string.Empty;

        [Required]
        [Comment("Vehicle color")]
        public string Color { get; set; } = string.Empty;

        [Comment("Vehicle images")]
        public  List<string> VehicleImages { get; set; } = new List<string>();

        [Comment("If vehicle is sold")]
        public bool IsSold = false;
 
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
