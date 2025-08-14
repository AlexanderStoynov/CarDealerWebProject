using CarDealerWebProject.Core.Models.Vehicle.FormModels;
using CarDealerWebProject.Infrastructure.Data.Models;

namespace CarDealerWebProject.Core.Factories
{
    public static class VehicleFactory
    {
        public static Vehicle Create(VehicleFormModel model)
        {
            if (model is PetrolCarFormModel petrolCar)
            {
                return new PetrolCar
                {
                    Make = petrolCar.Make,
                    Model = petrolCar.Model,
                    Color = petrolCar.Color,
                    Description = petrolCar.Description,
                    Transmission = petrolCar.Transmission,
                    ManufacturingDate = petrolCar.ManufacturingDate,
                    MotorHorsePower = petrolCar.MotorHorsePower,
                    Fuel = petrolCar.Fuel,
                    Price = petrolCar.Price,
                    Milage = petrolCar.Milage,
                    VehicleImages = petrolCar.VehicleImages,

                    CarBodyType = petrolCar.CarBodyType,
                    EngineCapacity = petrolCar.EngineCapacity
                };
            }

            if (model is HybridCarFormModel hybridCar)
            {
                return new HybridCar
                {
                    Make = hybridCar.Make,
                    Model = hybridCar.Model,
                    Color = hybridCar.Color,
                    Description = hybridCar.Description,
                    Transmission = hybridCar.Transmission,
                    ManufacturingDate = hybridCar.ManufacturingDate,
                    MotorHorsePower = hybridCar.MotorHorsePower,
                    Fuel = hybridCar.Fuel,
                    Price = hybridCar.Price,
                    Milage = hybridCar.Milage,
                    VehicleImages = hybridCar.VehicleImages,

                    CarBodyType = hybridCar.CarBodyType,
                    BatteryCapacity = hybridCar.BatteryCapacity,
                    EngineCapacity = hybridCar.EngineCapacity
                };
            }

            if (model is ElectricCarFormModel electricCar)
            {
                return new ElectricCar
                {
                    Make = electricCar.Make,
                    Model = electricCar.Model,
                    Color = electricCar.Color,
                    Description = electricCar.Description,
                    Transmission = electricCar.Transmission,
                    ManufacturingDate = electricCar.ManufacturingDate,
                    MotorHorsePower = electricCar.MotorHorsePower,
                    Fuel = electricCar.Fuel,
                    Price = electricCar.Price,
                    Milage = electricCar.Milage,
                    VehicleImages = electricCar.VehicleImages,

                    CarBodyType = electricCar.CarBodyType,
                    BatteryCapacity = electricCar.BatteryCapacity
                };
            }

            if (model is MotorcycleFormModel motorcycle)
            {
                return new Motorcycle
                {
                    Make = motorcycle.Make,
                    Model = motorcycle.Model,
                    Color = motorcycle.Color,
                    Description = motorcycle.Description,
                    Transmission = motorcycle.Transmission,
                    ManufacturingDate = motorcycle.ManufacturingDate,
                    MotorHorsePower = motorcycle.MotorHorsePower,
                    Fuel = motorcycle.Fuel,
                    Price = motorcycle.Price,
                    Milage = motorcycle.Milage,
                    VehicleImages = motorcycle.VehicleImages,

                    MotorcycleBodyType = motorcycle.MotorcycleBodyType,
                    EngineCapacity = motorcycle.EngineCapacity
                };
            }

            throw new ArgumentException("Unsupported vehicle type", nameof(model));
        }
    }
}
