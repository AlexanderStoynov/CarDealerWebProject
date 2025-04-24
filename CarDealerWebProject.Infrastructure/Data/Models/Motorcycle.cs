using CarDealerWebProject.Infrastructure.Data.Enums;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static CarDealerWebProject.Infrastructure.Constants.DataConstants;

namespace CarDealerWebProject.Infrastructure.Data.Models
{
    public class Motorcycle : Vehicle
    {
        [Comment("Motorcycle body type")]
        public MotorcycleBodyType MotorcycleBodyType { get; set; }

        [Range(VehicleEngineCapacityMin, VehicleEngineCapacityMax)]
        [Comment("Engine capacity")]
        public int EngineCapacity { get; set; }
    }
}
