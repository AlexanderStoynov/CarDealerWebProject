using CarDealerWebProject.Infrastructure.Data.Enums;
using System.ComponentModel.DataAnnotations;
using static CarDealerWebProject.Infrastructure.Constants.DataConstants;

namespace CarDealerWebProject.Core.Models.Vehicle.FormModels
{
    public class ElectricCarFormModel : VehicleFormModel
    {
        [Required]
        [Display(Name = "Body type")]
        public CarBodyType CarBodyType { get; set; }

        [Required]
        [Range(ElectricCarBatteryCapacityMin, ElectricCarBatteryCapacityMax)]
        [Display(Name = "Battery capacity")]
        public int BatteryCapacity { get; set; }

        public override VehicleTypes VehicleType => VehicleTypes.ElectricCar;
    }
}
