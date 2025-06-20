using CarDealerWebProject.Core.Models.Vehicle;
using CarDealerWebProject.Infrastructure.Data.Enums;

namespace CarDealerWebProject.Core.Contracts
{
    public interface IVehicleService
    {
        Task<IEnumerable<VehicleIndexServiceModel>> LastSixVehiclesAsync();

        Task<int> CreateAsync(VehicleFormModel model);

        Task<VehicleQueryServiceModel> AllAsync(
            VehicleSorting sorting = VehicleSorting.NewlyAdded,
            int currentPage = 1,
            int vehiclePerPage = 1);

        Task<bool> ExistsAsync(int id);

        Task<VehicleDetailsServiceModel> VehicleDetailsByIdAsync(int id);

        Task EditAsync(int vehicleId, VehicleFormModel model);

        Task<VehicleFormModel?> GetVehicleFormModelByIdAsync(int id);

        Task DeleteAsync(int vehicleId);
    }
}
