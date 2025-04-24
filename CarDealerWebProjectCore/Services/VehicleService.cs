using CarDealerWebProject.Core.Contracts;
using CarDealerWebProject.Core.Models.Vehicle;
using CarDealerWebProject.Infrastructure.Data.Common;
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

        public async Task<IEnumerable<VehicleCategoryServiceModel>> AllCategoriesAsync()
        {
            return await repository.AllReadOnly<Category>()
                 .Select(v => new VehicleCategoryServiceModel()
                 {
                     Id = v.Id,
                     Name = v.Name
                 })
                 .ToListAsync();
        }

        public async Task<bool> CategoryExistsAsync(int categoryId)
        {
            return await repository.AllReadOnly<Category>()
                .AnyAsync(c => c.Id == categoryId);
        }

        public async Task<int> CreateAsync(VehicleFormModel model)
        {
            Vehicle vehicle = new Vehicle()
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
                CategoryId = model.CategoryId,
            };

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
