using CarDealerWebProject.Core.Models.Home;

namespace CarDealerWebProject.Core.Contracts
{
    public interface IVehicleService
    {
        Task<IEnumerable<VehicleIndexServiceModel>> LastSixVehiclesAsync();
    }
}
