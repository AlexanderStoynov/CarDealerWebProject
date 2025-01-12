using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
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

        [Required]
        [Comment("Vehicle body type")]
        public required string BodyType { get; set; }

        [Range(typeof(decimal), VehiclePriceMin, VehiclePriceMax, ConvertValueInInvariantCulture = true)]
        [Comment("Vehicle price")]
        public decimal Price { get; set; }

        [Required]
        [Comment("Vehicle fuel type")]
        public required string Fuel { get; set; }

        [Range(VehicleMilageMin, VehicleMilageMax)]
        [Comment("Vehicle milage")]
        public int Milage { get; set; }

        [Range(VehicleMotorHorsePowerMin, VehicleMotorHorsePowerMax)]
        [Comment("Motor horse power")]
        public int MotorHorsePower { get; set; }

        [Range(VehicleEngineCapacityMin, VehicleEngineCapacityMax)]
        [Comment("Engine capacity")]
        public int EngineCapacity { get; set; }

        [MaxLength(VehicleDescriptionMaxLength)]
        [Comment("Vehicle description")]
        public string Description { get; set; } = string.Empty;

        [Comment("Vehicle images")]
        public  List<string> VehicleImages { get; set; } = new List<string>();

        [Comment("Date vehicle is listed")]
        public DateTime DateListed { get; set; }

        [Comment("If vehicle is sold")]
        public bool IsSold = false;
 
    }


    
    //    BodyType = "Sedan",
   
    //    Transmission = "Automatic",
 
    //    Color = "White",
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
