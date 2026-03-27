using CarDealerWebProject.Infrastructure.Data.Enums;
using CarDealerWebProject.Infrastructure.Data.Models;

namespace CarDealerWebProject.Core.Models.Vehicle.ViewModels
{
    public class VehicleDetailsViewModel 
    {
        public int Id { get; set; }

        public string Make { get; set; } = string.Empty;
         
        public string Model { get; set; } = string.Empty;

        public Transmission Transmission { get; set; }

        public DateOnly ManufacturingDate { get; set; }

        public decimal Price { get; set; }

        public int Mileage { get; set; }

        public List<Motor> Motors { get; set; } = new List<Motor>();

        public string Description { get; set; } = string.Empty;

        public string VehicleImages { get; set; } = string.Empty;

        public bool IsSold { get; set; }

        public VehicleTypes VehicleType { get; set; }

        //Non common properties
        public CarBodyType? CarBodyType { get; set; } = null;

        public MotorcycleBodyType? MotorcycleBodyType { get; set; }
    }
}
