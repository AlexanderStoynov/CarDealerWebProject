using CarDealerWebProject.Infrastructure.Data.Enums;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using static CarDealerWebProject.Infrastructure.Constants.DataConstants;

namespace CarDealerWebProject.Infrastructure.Data.Models
{
    public class Motorcycle : Vehicle
    {
        protected Motorcycle() { }
        
        [SetsRequiredMembers]
        public Motorcycle(VehicleCommon c, MotorcycleBodyType bodyType, int engineCapacity)
            : base(c)
        {
            MotorcycleBodyType = bodyType;
            EngineCapacity = engineCapacity;
        }
        
        [Required]
        [Comment("Motorcycle body type")]
        public MotorcycleBodyType MotorcycleBodyType { get; set; }

        [Range(PetrolVehicleEngineCapacityMin, PetrolVehicleEngineCapacityMax)]
        [Comment("Engine capacity")]
        public int EngineCapacity { get; set; }
    }
}
