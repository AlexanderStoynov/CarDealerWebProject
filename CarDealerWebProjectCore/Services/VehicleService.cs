using CarDealerWebProject.Core.Contracts;
using CarDealerWebProject.Core.Models.Vehicle;
using CarDealerWebProject.Infrastructure.Data.Common;
using CarDealerWebProject.Infrastructure.Data.Enums;
using CarDealerWebProject.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealerWebProject.Core.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly IRepository repository;

        public VehicleService(IRepository repository)
        {
            this.repository = repository;
        }

        public async Task<VehicleQueryServiceModel> AllAsync(string? searchTerm = null, VehicleSorting sorting = VehicleSorting.NewlyAdded, int currentPage = 1, int vehiclePerPage = 1)
        {
            var vehiclesToShow = repository.AllReadOnly<Vehicle>();

            if (searchTerm != null)
            {
                string normilizedSearchTerm = searchTerm.ToLower();
                vehiclesToShow = vehiclesToShow
                    .Where(v => (v.Make.ToLower().Contains(normilizedSearchTerm) ||
                                 v.Model.ToLower().Contains(normilizedSearchTerm)));
            }

            vehiclesToShow = sorting switch
            {
                VehicleSorting.PriceDescending => vehiclesToShow.OrderByDescending(v => v.Price),
                VehicleSorting.PriceAscending => vehiclesToShow.OrderBy(v => v.Price),
                VehicleSorting.Name => vehiclesToShow.OrderBy(v => v.Make).ThenBy(v => v.Model),
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
                    VehicleImage = v.VehicleImages[0]
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
            Vehicle vehicle = new Vehicle
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
            };

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

            if (model.SelectedType == VehicleTypes.HybridCar)
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

            if(model.SelectedType == VehicleTypes.ElectricCar)
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

            if(model.SelectedType == VehicleTypes.Motorcycle)
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

            await repository.AddAsync(vehicle);
            await repository.SaveChangesAsync();
            return vehicle.Id;
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
                    Model = v.Model
                }).ToListAsync();
        }
    }
}
