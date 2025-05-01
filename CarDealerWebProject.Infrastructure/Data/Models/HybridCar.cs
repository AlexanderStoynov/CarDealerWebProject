using CarDealerWebProject.Infrastructure.Data.Enums;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static CarDealerWebProject.Infrastructure.Constants.DataConstants;

namespace CarDealerWebProject.Infrastructure.Data.Models
{
    public class HybridCar : Vehicle
    {
        [Required]
        [Comment("Car body type")]
        public CarBodyType CarBodyType { get; set; }

        [Required]
        [Range(ElectricCarBatteryCapacityMin, ElectricCarBatteryCapacityMax)]
        [Comment("Battery capacity")]
        public int BatteryCapacity { get; set; }

        [Range(PetrolVehicleEngineCapacityMin, PetrolVehicleEngineCapacityMax)]
        [Comment("Engine capacity")]
        public int EngineCapacity { get; set; }
    }
}
