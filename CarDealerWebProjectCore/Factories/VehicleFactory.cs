using CarDealerWebProject.Core.Models.Vehicle.FormModels;
using CarDealerWebProject.Infrastructure.Data.Models;
using static CarDealerWebProject.Core.Constants.VehicleConstants;

namespace CarDealerWebProject.Core.Factories
{
    public static class VehicleFactory
    {
        public static Vehicle Create(VehicleFormModel model) =>
            model switch
            {
                PetrolCarFormModel petrolCar => new PetrolCar(ToCommon(petrolCar), petrolCar.CarBodyType, petrolCar.EngineCapacity),
                HybridCarFormModel hybridCar => new HybridCar(ToCommon(hybridCar), hybridCar.CarBodyType, hybridCar.EngineCapacity, hybridCar.BatteryCapacity),
                ElectricCarFormModel electricCar => new ElectricCar(ToCommon(electricCar), electricCar.CarBodyType, electricCar.BatteryCapacity),
                MotorcycleFormModel motorcycle => new Motorcycle(ToCommon(motorcycle), motorcycle.MotorcycleBodyType, motorcycle.EngineCapacity),
                _ => throw new ArgumentException(UnsupportedVehicleError)
            };
        private static VehicleCommon ToCommon(VehicleFormModel s) =>
            new(
                s.Make,
                s.Model,
                s.Color,
                s.Description,
                s.Transmission,
                s.ManufacturingDate,
                s.MotorHorsePower,
                s.Fuel,
                s.Price,
                s.Mileage,
                s.VehicleImages
            );   
    }
}
