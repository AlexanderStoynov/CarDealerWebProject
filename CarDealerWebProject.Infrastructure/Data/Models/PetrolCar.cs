using CarDealerWebProject.Infrastructure.Data.Enums;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static CarDealerWebProject.Infrastructure.Constants.DataConstants;

namespace CarDealerWebProject.Infrastructure.Data.Models
{
    public class PetrolCar : Vehicle
    {
        [Required]
        [Comment("The cars body type")]
        public CarBodyType CarBodyType { get; set; }

        [Range(VehicleEngineCapacityMin, VehicleEngineCapacityMax)]
        [Comment("Engine capacity")]
        public int EngineCapacity { get; set; }

    }
}
