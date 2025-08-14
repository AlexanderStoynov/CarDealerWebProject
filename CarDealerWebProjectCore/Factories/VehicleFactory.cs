using CarDealerWebProject.Core.Models.Vehicle.FormModels;
using CarDealerWebProject.Infrastructure.Data.Enums;
using CarDealerWebProject.Infrastructure.Data.Models;

namespace CarDealerWebProject.Core.Factories
{
    public static class VehicleFactory
    {
        public Vehicle CreateVehicle(VehicleFormModel model)
        {
            Vehicle vehicle = model switch
            {
                PetrolCarFormModel petrol => new PetrolCar
                {
                    CarBodyType = petrol.CarBodyType,
                    EngineCapacity = petrol.EngineCapacity
                },
                HybridCarFormModel hybrid => new HybridCar
                {
                    CarBodyType = hybrid.CarBodyType,
                    BatteryCapacity = hybrid.BatteryCapacity,
                    EngineCapacity = hybrid.EngineCapacity
                },
                ElectricCarFormModel electric => new ElectricCar
                {
                    CarBodyType = electric.CarBodyType,
                    BatteryCapacity = electric.BatteryCapacity
                },
                MotorcycleFormModel moto => new Motorcycle
                {
                    MotorcycleBodyType = moto.MotorcycleBodyType,
                    EngineCapacity = moto.EngineCapacity
                },
                _ => throw new ArgumentException("Unsupported vehicle type", nameof(form))
            };

            // Copy base props once here
            CopyBaseProperties(form, vehicle);

            return vehicle;
        }

        private static void CopyBaseProperties(VehicleFormModel form, Vehicle vehicle)
        {
            vehicle.Make = form.Make;
            vehicle.Model = form.Model;
            vehicle.Color = form.Color;
            vehicle.Description = form.Description;
            vehicle.Transmission = form.Transmission;
            vehicle.ManufacturingDate = form.ManufacturingDate;
            vehicle.MotorHorsePower = form.MotorHorsePower;
            vehicle.Fuel = form.Fuel;
            vehicle.Price = form.Price;
            vehicle.Milage = form.Milage;
            vehicle.VehicleImages = form.VehicleImages;
        }
    }   
}
