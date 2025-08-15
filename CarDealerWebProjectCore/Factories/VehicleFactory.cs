using CarDealerWebProject.Core.Models.Vehicle.FormModels;
using CarDealerWebProject.Infrastructure.Data.Models;

namespace CarDealerWebProject.Core.Factories
{
    public static class VehicleFactory
    {
        public static Vehicle Create(VehicleFormModel model) =>
            model switch
            {
                PetrolCarFormModel p => new PetrolCar(ToCommon(p), p.CarBodyType, p.EngineCapacity),
                HybridCarFormModel h => new HybridCar(ToCommon(h), h.CarBodyType, h.EngineCapacity, h.BatteryCapacity),
                ElectricCarFormModel e => new ElectricCar(ToCommon(e), e.CarBodyType, e.BatteryCapacity),
                MotorcycleFormModel m => new Motorcycle(ToCommon(m), m.MotorcycleBodyType, m.EngineCapacity),
                _ => throw new ArgumentException("Unsupported vehicle type", nameof(model))
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
                s.Milage,
                s.VehicleImages
            );
    }

}
