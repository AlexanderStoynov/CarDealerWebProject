using CarDealerWebProject.Infrastructure.Data.Enums;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static CarDealerWebProject.Infrastructure.Constants.DataConstants;

namespace CarDealerWebProject.Infrastructure.Data.Models
{
    public class PetrolCar : Vehicle
    {
        public PetrolCar(RequiredVehicleProperties req, CarBodyType carBodyType, int engineCapacity)
        : base(req.Make, req.Model, req.Color, req.Description)
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
