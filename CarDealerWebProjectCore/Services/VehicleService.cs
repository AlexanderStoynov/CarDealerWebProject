using CarDealerWebProject.Core.Contracts.Services;
using CarDealerWebProject.Core.Models.Vehicle;
using CarDealerWebProject.Core.Models.Vehicle.FormModels;
using CarDealerWebProject.Core.Models.Vehicle.SeviceModels;
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

        public async Task<VehiclePreviewQueryServiceModel> AllVehiclesAsync(VehicleSorting sorting = VehicleSorting.NewlyAdded, int currentPage = 1, int vehiclePerPage = 1)
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
                .Select(v => new VehiclePreviewServiceModel()
                {
                    Id = v.Id,
                    Make = v.Make,
                    Model = v.Model,
                    Price = v.Price,
                    HorsePower = v.Motors.Sum(m => m.MotorHorsePower),
                    FirstVehicleImage = v.VehicleImages.FirstOrDefault() ?? ""
                })
                .ToListAsync();

            int totalVehicles = await vehiclesToShow.CountAsync();

            return new VehiclePreviewQueryServiceModel()
            {
                Vehicles = vehicles,
                TotalVehicleCount = totalVehicles
            };
        }

        public async Task<IEnumerable<VehiclePreviewServiceModel>> LastSixVehiclesAsync()
        {
            return await repository
                .AllReadOnly<Vehicle>()
                .OrderByDescending(v => v.Id)
                .Take(6)
                .Select(v => new VehiclePreviewServiceModel()
                {
                    Id = v.Id,
                    Make = v.Make,
                    Model = v.Model,
                    Price = v.Price,
                    HorsePower = v.Motors.Sum(m => m.MotorHorsePower),
                    FirstVehicleImage = v.VehicleImages.FirstOrDefault() ?? ""
                }).ToListAsync();
        }

        public async Task<int> CreateVehicleAsync(Vehicle vehicle)
        {
            if (vehicle == null)
            {
                throw new ArgumentNullException(FailedToCreateVehicleError);
            }

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
            return await repository.AllReadOnly<Vehicle>()
                .Where(v => v.Id == id)
                .Select(v => new VehicleFormModel()
                {
                    Make = v.Make,
                    Model = v.Model,
                    Color = v.Color,
                    Price = v.Price,
                    ManufacturingDate = v.ManufacturingDate,
                    Transmission = v.Transmission,
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
                    Transmission = v.Transmission,
                    Description = v.Description,
                    VehicleImage = v.VehicleImages,
                })
                .FirstAsync();
        }

        public async Task<VehiclePreviewServiceModel> VehiclePreviewByIdAsync(int id)
        {
            return await repository.AllReadOnly<Vehicle>()
                .Where(v => v.Id == id)
                .Select(v => new VehiclePreviewServiceModel()
                {
                    Id = v.Id,
                    Make = v.Make,
                    Model = v.Model,
                    Price = v.Price,
                    HorsePower = v.Motors.Sum(m => m.MotorHorsePower),
                    FirstVehicleImage = v.VehicleImages.FirstOrDefault() ?? ""
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
                vehicle.Transmission = model.Transmission;
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
            var vehicle = await repository.GetByIdAsync<Vehicle>(id);

            if (vehicle == null)
            {
                throw new Exception(VehicleNotFoundMessage);
            }

            await repository.DeleteAsync<Vehicle>(id);
            await repository.SaveChangesAsync();
        }
    }
}
