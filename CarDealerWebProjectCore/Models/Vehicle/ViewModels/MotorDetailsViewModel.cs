using CarDealerWebProject.Infrastructure.Data.Enums;

namespace CarDealerWebProject.Core.Models.Vehicle.ViewModels
{
    public class MotorDetailsViewModel
    {
        public int Id { get; set; }

        public FuelType Fuel { get; set; }

        public int MotorHorsePower { get; set; } 

        public int? EngineCapacityCC { get; set; }

        public int? BatteryCapacitykWh { get; set; }
    }
}
