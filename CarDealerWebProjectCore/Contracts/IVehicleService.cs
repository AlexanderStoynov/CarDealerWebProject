using CarDealerWebProject.Core.Models.Vehicle;
using CarDealerWebProject.Infrastructure.Data.Enums;

namespace CarDealerWebProject.Core.Contracts
{
    public interface IVehicleService
    {
        Task<IEnumerable<VehicleIndexServiceModel>> LastSixVehiclesAsync();

        Task<int> CreateAsync(VehicleFormModel model);

        Task<VehicleQueryServiceModel> AllAsync(
            string? searchTerm = null,
            VehicleSorting sorting = VehicleSorting.NewlyAdded,
            int currentPage = 1,
            int vehiclePerPage = 1);
    }
}
