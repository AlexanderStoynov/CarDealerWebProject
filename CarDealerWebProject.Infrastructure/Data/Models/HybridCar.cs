using CarDealerWebProject.Infrastructure.Data.Enums;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using static CarDealerWebProject.Infrastructure.Constants.DataConstants;

namespace CarDealerWebProject.Infrastructure.Data.Models
{
    public class HybridCar : Vehicle
    { 
        protected HybridCar() { }

        [SetsRequiredMembers]
        public HybridCar(VehicleCommon common, CarBodyType carBodyType, int engineCapacity, int batteryCapacity)
            : base(common)
        {
            CarBodyType = carBodyType;
            EngineCapacity = engineCapacity;
            BatteryCapacity = batteryCapacity;
        }

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
