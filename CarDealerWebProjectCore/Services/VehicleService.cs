 using CarDealerWebProject.Core.Contracts;
using CarDealerWebProject.Core.Factories;
using CarDealerWebProject.Core.Models.Vehicle;
using CarDealerWebProject.Core.Models.Vehicle.FormModels;
using CarDealerWebProject.Infrastructure.Data.Common;
using CarDealerWebProject.Infrastructure.Data.Enums;
using CarDealerWebProject.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using static CarDealerWebProject.Core.Constants.VehicleConstants;

namespace CarDealerWebProject.Core.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly IRepository repository;

        public VehicleService(IRepository repository)
        {
            this.repository = repository;
        }

        public async Task<VehicleQueryServiceModel> AllVehiclesAsync(VehicleSorting sorting = VehicleSorting.NewlyAdded, int currentPage = 1, int vehiclePerPage = 1)
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

        public async Task<int> CreateVehicleAsync(VehicleFormModel vehicleModel)
        {
            if (vehicleModel == null)
            {
                throw new ArgumentNullException(nameof(vehicleModel));
            }

            Vehicle vehicle = VehicleFactory.Create(vehicleModel);

            await repository.AddAsync(vehicle);
            await repository.SaveChangesAsync();
            return vehicle.Id;
        }

        public async Task<bool> VehicleExistsByIdAsync(int id)
        {
            return await repository.AllReadOnly<Vehicle>()
                .AnyAsync(v => v.Id == id);
        }

        public async Task<VehicleFormModel?> GetVehicleFormModelByIdAsync(int id)
        {
            throw new NotImplementedException();

            //return await repository.AllReadOnly<Vehicle>()
            //    .Where(v => v.Id == id)
            //    .Select(v => new VehicleFormModel()
            //    {
            //        Make = v.Make,
            //        Model = v.Model,
            //        Color = v.Color,
            //        Price = v.Price,
            //        ManufacturingDate = v.ManufacturingDate,
            //        Fuel = v.Fuel,
            //        MotorHorsePower = v.MotorHorsePower,
            //        Transmission = v.Transmission,
            //        Milage = v.Milage,
            //        Description = v.Description,
            //        VehicleImages = v.VehicleImages,
            //    })
            //    .FirstOrDefaultAsync();
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

        public async Task EditVehicleAsync(int vehicleId, VehicleFormModel model)
        {
            var vehicle = await repository.GetByIdAsync<Vehicle>(vehicleId);

            if (vehicle != null)
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

            else
            {
                throw new Exception(VehicleNotFoundMessage);
            }
        }

        public async Task DeleteVehicleAsync(int id)
        {
            var vehicle = repository.GetByIdAsync<Vehicle>(id);

            if (vehicle == null)
            {
                throw new Exception(VehicleNotFoundMessage);
            }

            await repository.DeleteAsync<Vehicle>(id);
            await repository.SaveChangesAsync();
        }
    }
}
