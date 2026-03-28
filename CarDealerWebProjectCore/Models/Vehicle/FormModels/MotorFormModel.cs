using CarDealerWebProject.Core.Contracts.Models;
using CarDealerWebProject.Infrastructure.Data.Enums;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static CarDealerWebProject.Infrastructure.Constants.DataConstants;
using static CarDealerWebProject.Core.Constants.MessageConstants;

namespace CarDealerWebProject.Core.Models.Vehicle.FormModels
{
    public class MotorFormModel : IMotorModel
    {
        [Comment("Motor identifier")]
        public int Id { get; set; }

        [Required(ErrorMessage = RequiredMessage)]
        [Comment("Vehicle fuel type")]
        public FuelType Fuel { get; set; }

        [Required(ErrorMessage = RequiredMessage)]
        [Range(MotorHorsePowerMin, MotorHorsePowerMax)]
        [Comment("Motor horse power")]
        public int MotorHorsePower { get; set; }

        [Range(EngineCapacityCCMin, EngineCapacityCCMax)]
        [Comment("Engine capacity")]
        public int? EngineCapacityCC { get; set; }

        [Range(BatteryCapacityMin, BatteryCapacityMax)]
        [Comment("Battery capacity")]
        public int? BatteryCapacitykWh { get; set; }

    }
}
