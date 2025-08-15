using CarDealerWebProject.Infrastructure.Data.Enums;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using static CarDealerWebProject.Infrastructure.Constants.DataConstants;

namespace CarDealerWebProject.Infrastructure.Data.Models
{
    public class ElectricCar : Vehicle
    {
        protected ElectricCar() { }
        
        [SetsRequiredMembers]
        public ElectricCar(VehicleCommon c, CarBodyType carBodyType, int batteryCapacity)
            : base(c)
        {
            CarBodyType = carBodyType;
            BatteryCapacity = batteryCapacity;
        }
        
        [Required]
        [Comment("Car body type")]
        public CarBodyType CarBodyType { get; set; }

        [Required]
        [Range(ElectricCarBatteryCapacityMin, ElectricCarBatteryCapacityMax)]
        [Comment("Battery capacity")]
        public int BatteryCapacity { get; set; }
    }
}
