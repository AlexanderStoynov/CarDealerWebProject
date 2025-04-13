using CarDealerWebProject.Core.Contracts.Vehicle;
using CarDealerWebProject.Core.Models.Home;
using CarDealerWebProject.Infrastructure.Data.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealerWebProject.Core.Services.Vehicle
{
    public class VehicleService : IVehicleService
    {
        private readonly IRepository repository;

        public VehicleService(IRepository repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<VehicleIndexServiceModel>> LastSixVehicles()
        {
            return await repository
                .AllReadOnly<Infrastructure.Data.Models.Vehicle>()
                .OrderByDescending(v => v.Id)
                .Take(6)
                .Select(v => new VehicleIndexServiceModel()
                {
                    Id = v.Id,
                    VehicleImages = v.VehicleImages,
                    Make = v.Make,
                    Model = v.Model
                }).ToListAsync();
        }
    }
}
