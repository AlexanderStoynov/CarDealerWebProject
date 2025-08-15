using CarDealerWebProject.Infrastructure.Data.Enums;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using static CarDealerWebProject.Infrastructure.Constants.DataConstants;

namespace CarDealerWebProject.Infrastructure.Data.Models
{
    public class PetrolCar : Vehicle
    {
        protected PetrolCar() { }

        [SetsRequiredMembers]
        public PetrolCar(VehicleCommon c, CarBodyType carBodyType, int engineCapacity)
            : base(c)
        {
            CarBodyType = carBodyType;
            EngineCapacity = engineCapacity;
        }

        [Required]
        [Comment("Car body type")]
        public CarBodyType CarBodyType { get; set; }

        [Range(PetrolVehicleEngineCapacityMin, PetrolVehicleEngineCapacityMax)]
        [Comment("Engine capacity")]
        public int EngineCapacity { get; set; }

    }
}
