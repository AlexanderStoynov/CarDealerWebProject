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
        public required string Make { get; set; } = string.Empty;

        [Required]
        [StringLength(VehicleModelMaxLength, MinimumLength = VehicleModelMinLength)]
        [Comment("Vehicle model")]
        public required string Model { get; set; } = string.Empty;

        [Required]
        [StringLength(VehicleColorMaxLength, MinimumLength = VehicleColorMinLength)]
        [Comment("Vehicle color")]
        public required string Color { get; set; } = string.Empty;

        [Comment("Vehicle transmission")]
        public Transmission Transmission { get; set; }

        [Comment("Vehicle manufacturing date")]
        public DateOnly ManufacturingDate { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        [Range(typeof(decimal), VehiclePriceMin, VehiclePriceMax, ConvertValueInInvariantCulture = true)]
        [Comment("Vehicle price")]
        public decimal Price { get; set; }

        [Range(VehicleMileageMin, VehicleMileageMax)]
        [Comment("Vehicle mileage")]
        public int Mileage { get; set; }

        [Comment("Vehicle motor")]
        public ICollection<Motor> Motors { get; set; } = new List<Motor>();

        [StringLength(VehicleDescriptionMaxLength, MinimumLength = VehicleDescriptionMinLength)]
        [Comment("Vehicle description")]
        public required string Description { get; set; } = string.Empty;

        [Required]
        [Comment("Vehicle images")]
        public required List<string> VehicleImages { get; set; } = new List<string>();

        [Comment("If vehicle is sold")]
        public bool IsSold { get; set; } = false;

        [Required]
        [Comment("Type of vehicle")]
        public VehicleTypes VehicleType { get; set; }

        //Non common properties

        [Comment("Car body type")]
        public CarBodyType? CarBodyType { get; set; } = null;

        [Comment("Motorcycle body type")]
        public MotorcycleBodyType? MotorcycleBodyType { get; set; }
    }

    //    SellerName = "John Doe",
    //    SellerPhone = "+359 123 456 789
}
