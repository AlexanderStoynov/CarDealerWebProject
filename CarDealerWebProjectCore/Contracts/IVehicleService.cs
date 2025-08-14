using CarDealerWebProject.Core.Models.Vehicle;
using CarDealerWebProject.Core.Models.Vehicle.FormModels;
using CarDealerWebProject.Infrastructure.Data.Enums;

namespace CarDealerWebProject.Core.Contracts
{
    public interface IVehicleService
    {
        Task<int> CreateVehicleAsync(VehicleFormModel model);

        Task<IEnumerable<VehicleIndexServiceModel>> LastSixVehiclesAsync();

        Task<VehicleQueryServiceModel> AllVehiclesAsync(
            VehicleSorting sorting = VehicleSorting.NewlyAdded,
            int currentPage = 1,
            int vehiclePerPage = 1);

        Task<bool> VehicleExistsByIdAsync(int id);

        Task<VehicleDetailsServiceModel> VehicleDetailsByIdAsync(int id);

        Task EditVehicleAsync(int id, VehicleFormModel model);

        Task<VehicleFormModel?> GetVehicleFormModelByIdAsync(int id);

        Task DeleteVehicleAsync(int id);
    }
}
