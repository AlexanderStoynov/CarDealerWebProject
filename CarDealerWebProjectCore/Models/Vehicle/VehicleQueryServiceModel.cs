namespace CarDealerWebProject.Core.Models.Vehicle
{
    public class VehicleQueryServiceModel
    {
        public int TotalVehicleCount { get; set; }

        public IEnumerable<VehicleServiceModel> Vehicles { get; set; } = new List<VehicleServiceModel>();
    }
}
