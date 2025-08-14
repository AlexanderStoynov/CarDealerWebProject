using CarDealerWebProject.Infrastructure.Data.Enums;
using System.ComponentModel.DataAnnotations;
using static CarDealerWebProject.Infrastructure.Constants.DataConstants;

namespace CarDealerWebProject.Core.Models.Vehicle.FormModels
{
    public class MotorcycleFormModel : VehicleFormModel 
    {
        [Required]
        [Display(Name = "Body type")]
        public MotorcycleBodyType MotorcycleBodyType { get; set; }

        [Required]
        [Range(PetrolVehicleEngineCapacityMin, PetrolVehicleEngineCapacityMax)]
        [Display(Name = "Engine capacity")]
        public int EngineCapacity { get; set; }

        public override VehicleTypes VehicleType => VehicleTypes.Motorcycle;
    }
}
