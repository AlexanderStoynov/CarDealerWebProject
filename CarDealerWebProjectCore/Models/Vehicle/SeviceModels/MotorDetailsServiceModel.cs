using CarDealerWebProject.Infrastructure.Data.Enums;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static CarDealerWebProject.Infrastructure.Constants.DataConstants;

namespace CarDealerWebProject.Core.Models.Vehicle.SeviceModels
{
    public class MotorDetailsServiceModel
    {
        [Key]
        [Comment("Motor identifier")]
        public int Id { get; set; }

        [Comment("Vehicle fuel type")]
        public FuelType Fuel { get; set; }

        [Range(MotorHorsePowerMin, MotorHorsePowerMax)]
        [Comment("Motor horse power")]
        public int MotorHorsePower { get; set; }

        [Range(EngineCapacityCCMin, EngineCapacityCCMax)]
        [Comment("Engine capacity")]
        public int? EngineCapacityCC { get; set; }

        [Range(BatteryCapacityMin, BatteryCapacityMax)]
        [Comment("Battery capacity")]
        public int? BatteryCapacitykWh { get; set; }

        [Comment("Vehicle identifier")]
        public int VehicleId { get; set; }
    }
}
