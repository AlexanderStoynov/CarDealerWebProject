using CarDealerWebProject.Infrastructure.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace CarDealerWebProject.Core.Models.Vehicle
{
    public class AllVehiclesQueryModel
    {
        public int VehiclesPerPage { get; } = 9;

        public VehicleSorting Sorting { get; set; }

        public int CurrentPage { get; set; } = 1;

        public int TotalVehiclesCount { get; set; }

        public IEnumerable<VehicleServiceModel> Vehicles { get; set; } = new List<VehicleServiceModel>();

    }
}
