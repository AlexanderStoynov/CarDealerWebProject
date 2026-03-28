using CarDealerWebProject.Infrastructure.Data.Enums;

namespace CarDealerWebProject.Core.Contracts.Models
{
    internal interface IMotorModel
    {
        public FuelType Fuel { get; set; }

        public int MotorHorsePower { get; set; }

    }
}
