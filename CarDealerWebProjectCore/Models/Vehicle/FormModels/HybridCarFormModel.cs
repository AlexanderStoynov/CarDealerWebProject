using CarDealerWebProject.Infrastructure.Data.Enums;
using System.ComponentModel.DataAnnotations;
using static CarDealerWebProject.Infrastructure.Constants.DataConstants;

namespace CarDealerWebProject.Core.Models.Vehicle.FormModels
{
    public class HybridCarFormModel : VehicleFormModel
    {
        [Required]
        [Display(Name = "Body type")]
        public CarBodyType CarBodyType { get; set; }

        [Required]
        [Range(PetrolVehicleEngineCapacityMin, PetrolVehicleEngineCapacityMax)]
        [Display(Name = "Engine capacity")]
        public int EngineCapacity { get; set; }

        [Required]
        [Range(ElectricCarBatteryCapacityMin, ElectricCarBatteryCapacityMax)]
        [Display(Name = "Battery capacity")]
        public int BatteryCapacity { get; set; }

        public override VehicleTypes VehicleType => VehicleTypes.HybridCar;
    }
}
