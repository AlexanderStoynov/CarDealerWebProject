using CarDealerWebProject.Core.Models.Vehicle;

namespace CarDealerWebProject.Core.Contracts
{
    public interface IVehicleService
    {
        Task<IEnumerable<VehicleIndexServiceModel>> LastSixVehiclesAsync();

        Task<IEnumerable<VehicleCategoryServiceModel>> AllCategoriesAsync();

        Task<bool> CategoryExistsAsync(int categoryId);

        Task<int> CreateAsync(VehicleFormModel model);
    }
}
