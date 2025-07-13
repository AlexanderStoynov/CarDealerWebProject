using CarDealerWebProject.Core.Contracts;
using CarDealerWebProject.Core.Models.Vehicle;
using CarDealerWebProject.Infrastructure.Data.Common;
using CarDealerWebProject.Infrastructure.Data.Enums;
using CarDealerWebProject.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CarDealerWebProject.Core.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly IRepository repository;

        public VehicleService(IRepository repository)
        {
            this.repository = repository;
        }

        public async Task<VehicleQueryServiceModel> AllAsync(VehicleSorting sorting = VehicleSorting.NewlyAdded, int currentPage = 1, int vehiclePerPage = 1)
        {
            var vehiclesToShow = repository.AllReadOnly<Vehicle>();

            vehiclesToShow = sorting switch
            {
                VehicleSorting.PriceDescending => vehiclesToShow.OrderByDescending(v => v.Price),
                VehicleSorting.PriceAscending => vehiclesToShow.OrderBy(v => v.Price),
                VehicleSorting.Alphabetical => vehiclesToShow.OrderBy(v => v.Make).ThenBy(v => v.Model),
                _ => vehiclesToShow.OrderByDescending(v => v.Id)
            };

            var vehicles = await vehiclesToShow
                .Skip((currentPage - 1) * vehiclePerPage)
                .Take(vehiclePerPage)
                .Select(v => new VehicleServiceModel()
                {
                    Id = v.Id,
                    Make = v.Make,
                    Model = v.Model,
                    Price = v.Price,
                    MotorHorsePower = v.MotorHorsePower,
                    VehicleImages = v.VehicleImages
                })
                .ToListAsync();

            int totalVehicles = await vehiclesToShow.CountAsync();

            return new VehicleQueryServiceModel()
            {
                Vehicles = vehicles,
                TotalVehicleCount = totalVehicles
            };
        }

        public async Task<int> CreateAsync(VehicleFormModel model)
        {
            Vehicle vehicle;

            if (model.SelectedType == VehicleTypes.PetrolCar)
            {
                vehicle = new PetrolCar
                {
                    Make = model.Make,
                    Model = model.Model,
                    ManufacturingDate = model.ManufacturingDate,
                    Price = model.Price,
                    Fuel = model.Fuel,
                    Milage = model.Milage,
                    MotorHorsePower = model.MotorHorsePower,
                    Transmission = model.Transmission,
                    Color = model.Color,
                    Description = model.Description,
                    VehicleImages = model.VehicleImages,
                    CarBodyType = model.PetrolCarProperties!.CarBodyType,
                    EngineCapacity = model.PetrolCarProperties.EngineCapacity
                };
            }

            else if (model.SelectedType == VehicleTypes.HybridCar)
            {
                vehicle = new HybridCar
                {
                    Make = model.Make,
                    Model = model.Model,
                    ManufacturingDate = model.ManufacturingDate,
                    Price = model.Price,
                    Fuel = model.Fuel,
                    Milage = model.Milage,
                    MotorHorsePower = model.MotorHorsePower,
                    Transmission = model.Transmission,
                    Color = model.Color,
                    Description = model.Description,
                    VehicleImages = model.VehicleImages,
                    CarBodyType = model.HybridCarProperties!.CarBodyType,
                    EngineCapacity = model.HybridCarProperties.EngineCapacity,
                    BatteryCapacity = model.HybridCarProperties.BatteryCapacity
                };
            }

            else if (model.SelectedType == VehicleTypes.ElectricCar)
            {
                vehicle = new ElectricCar
                {
                    Make = model.Make,
                    Model = model.Model,
                    ManufacturingDate = model.ManufacturingDate,
                    Price = model.Price,
                    Fuel = model.Fuel,
                    Milage = model.Milage,
                    MotorHorsePower = model.MotorHorsePower,
                    Transmission = model.Transmission,
                    Color = model.Color,
                    Description = model.Description,
                    VehicleImages = model.VehicleImages,
                    CarBodyType = model.ElectricCarProperties!.CarBodyType,
                    BatteryCapacity = model.ElectricCarProperties.BatteryCapacity
                };
            }

            else if (model.SelectedType == VehicleTypes.Motorcycle)
            {
                vehicle = new Motorcycle
                {
                    Make = model.Make,
                    Model = model.Model,
                    ManufacturingDate = model.ManufacturingDate,
                    Price = model.Price,
                    Fuel = model.Fuel,
                    Milage = model.Milage,
                    MotorHorsePower = model.MotorHorsePower,
                    Transmission = model.Transmission,
                    Color = model.Color,
                    Description = model.Description,
                    VehicleImages = model.VehicleImages,
                    MotorcycleBodyType = model.MotorcycleProperties!.MotorcycleBodyType,
                    EngineCapacity = model.MotorcycleProperties.EngineCapacity
                };
            }

            else
            {
                throw new Exception("Vehicle not supported");
            }

            await repository.AddAsync(vehicle);
            await repository.SaveChangesAsync();
            return vehicle.Id;
        }

        public async Task EditAsync(int vehicleId, VehicleFormModel model)
        {
            var vehicle = await repository.GetByIdAsync<Vehicle>(vehicleId);

            if(vehicle != null)
            {
                vehicle.Make = model.Make;
                vehicle.Model = model.Model;
                vehicle.Color = model.Color;
                vehicle.Price = model.Price;
                vehicle.ManufacturingDate = model.ManufacturingDate;
                vehicle.Fuel = model.Fuel;
                vehicle.MotorHorsePower = model.MotorHorsePower;
                vehicle.Transmission = model.Transmission;
                vehicle.Milage = model.Milage;
                vehicle.Description = model.Description;
                vehicle.VehicleImages = model.VehicleImages;

                await repository.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await repository.AllReadOnly<Vehicle>()
                .AnyAsync(v => v.Id == id);
        }

        public async Task DeleteAsync(int vehicleId)
        {
            await repository.DeleteAsync<Vehicle>(vehicleId);
            await repository.SaveChangesAsync();
        }

        public async Task<VehicleFormModel?> GetVehicleFormModelByIdAsync(int id)
        {
            return await repository.AllReadOnly<Vehicle>()
                .Where(v => v.Id == id)
                .Select(v => new VehicleFormModel()
                {
                    Make = v.Make,
                    Model = v.Model,
                    Color = v.Color,
                    Price = v.Price,
                    ManufacturingDate = v.ManufacturingDate,
                    Fuel = v.Fuel,
                    MotorHorsePower = v.MotorHorsePower,
                    Transmission = v.Transmission,
                    Milage = v.Milage,
                    Description = v.Description,
                    VehicleImages = v.VehicleImages,
                })
                .FirstOrDefaultAsync();
        }

        public async Task<VehicleDetailsServiceModel> VehicleDetailsByIdAsync(int id)
        {
            return await repository.AllReadOnly<Vehicle>()
                .Where(v => v.Id == id)
                .Select(v => new VehicleDetailsServiceModel()
                {
                    Id = v.Id,
                    Make = v.Make,
                    Model = v.Model,
                    Color = v.Color,
                    Price = v.Price,
                    ManufacturingDate = v.ManufacturingDate,
                    Fuel = v.Fuel,
                    MotorHorsePower = v.MotorHorsePower,
                    Transmission = v.Transmission,
                    Milage = v.Milage,
                    Description = v.Description,
                    VehicleImages = v.VehicleImages,
                })
                .FirstAsync();
        }

        public async Task<IEnumerable<VehicleIndexServiceModel>> LastSixVehiclesAsync()
        {
            return await repository
                .AllReadOnly<Vehicle>()
                .OrderByDescending(v => v.Id)
                .Take(6)
                .Select(v => new VehicleIndexServiceModel()
                {
                    Id = v.Id,
                    VehicleImage = v.VehicleImages[0],
                    Make = v.Make,
                    Model = v.Model,
                    MotorHorsePower = v.MotorHorsePower
                }).ToListAsync();
        }
    }
}
