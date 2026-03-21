namespace CarDealerWebProject.Core.Models.Vehicle.SeviceModels
{
    public class VehiclePreviewQueryServiceModel
    {
        public int TotalVehicleCount { get; set; }

        public IEnumerable<VehiclePreviewServiceModel> Vehicles { get; set; } = new List<VehiclePreviewServiceModel>();
    }
}
