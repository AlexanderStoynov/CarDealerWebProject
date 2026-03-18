using CarDealerWebProject.Core.Models.Vehicle.SeviceModels;
using CarDealerWebProject.Infrastructure.Data.Enums;

namespace CarDealerWebProject.Core.Models.Vehicle
{
    public class AllVehiclesQueryModel
    {
        public int VehiclesPerPage { get; } = 9;

        public VehicleSorting Sorting { get; set; }

        public int CurrentPage { get; set; } = 1;

        public int TotalVehiclesCount { get; set; }

        public IEnumerable<VehiclePreviewServiceModel> Vehicles { get; set; } = new List<VehiclePreviewServiceModel>();

    }
}
