using CarDealerWebProject.Infrastructure.Data.Enums;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static CarDealerWebProject.Infrastructure.Constants.DataConstants;

namespace CarDealerWebProject.Core.Models.Vehicle.FormModels
{
    public class MotorcycleFormModel : VehicleFormModel 
    {
        [Required]
        [Comment("Motorcycle body type")]
        public MotorcycleBodyType MotorcycleBodyType { get; set; }

        [Required]
        [Range(PetrolVehicleEngineCapacityMin, PetrolVehicleEngineCapacityMax)]
        [Comment("Engine capacity")]
        public int EngineCapacity { get; set; }

        public override VehicleTypes VehicleType => VehicleTypes.Motorcycle;
    }
}
