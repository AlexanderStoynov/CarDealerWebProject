using CarDealerWebProject.Core.Models.Home;

namespace CarDealerWebProject.Core.Contracts.Vehicle
{
    public interface IVehicleService
    {
        Task<IEnumerable<VehicleIndexServiceModel>> LastSixVehicles();
    }
}
