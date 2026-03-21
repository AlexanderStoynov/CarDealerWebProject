using CarDealerWebProject.Core.Contracts.Models;

namespace CarDealerWebProject.Core.Models.Vehicle
{
    public class VehicleIndexServiceModel : IVehicleModel
    {
        public int Id { get; set; }

        public string Make { get; set; } = string.Empty;
        
        public string Model { get; set; } = string.Empty;

        public int HorsePower { get; set; }

        public decimal Price { get; set; }

        public string VehicleImage { get; set; } = string.Empty;

    }
}
