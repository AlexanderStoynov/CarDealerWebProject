using CarDealerWebProject.Core.Models.Vehicle.FormModels;
using CarDealerWebProject.Infrastructure.Data.Models;
using static CarDealerWebProject.Core.Constants.VehicleConstants;

namespace CarDealerWebProject.Core.Factories
{
    public static class VehicleFactory
    {
        public static Vehicle Create<T>(T model) where T : VehicleFormModel
        {
            var vehicle = new Vehicle
            {
                Make = model.Make,
                Model = model.Model,
                Color = model.Color,
                Transmission = model.Transmission,
                ManufacturingDate = model.ManufacturingDate,
                Price = model.Price,
                Mileage = model.Mileage,
                Motors = new List<Motor>(),
                Description = model.Description,
                VehicleImages = model.VehicleImages,
                VehicleType = model.VehicleType,
            };

            vehicle.Motors = model.Motors.Select(m => new Motor 
            {
                Fuel = m.Fuel,
                MotorHorsePower = m.MotorHorsePower,
                EngineCapacityCC = m.EngineCapacityCC,
                BatteryCapacitykWh = m.BatteryCapacitykWh,
                Vehicle = vehicle,
                
            }).ToList();

            switch (model)
            {
                case CarFormModel car:
                    vehicle.CarBodyType = car.CarBodyType;
                    break;

                case MotorcycleFormModel motorcycle:
                    vehicle.MotorcycleBodyType = motorcycle.MotorcycleBodyType;
                    break;

                default:
                    throw new ArgumentException(UnsupportedVehicleError);
            }

            return vehicle;
        }
    }
}
