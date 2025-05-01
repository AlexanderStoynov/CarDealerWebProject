using CarDealerWebProject.Infrastructure.Data.Enums;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static CarDealerWebProject.Infrastructure.Constants.DataConstants;

namespace CarDealerWebProject.Core.Models.Vehicle
{
    public class PetrolCarFormModel : VehicleFormModel
    {
        [Required]
        [Comment("Car body type")]
        public CarBodyType CarBodyType { get; set; }

        [Required]
        [Range(PetrolVehicleEngineCapacityMin, PetrolVehicleEngineCapacityMax)]
        [Comment("Engine capacity")]
        public int EngineCapacity { get; set; }
    }
}
