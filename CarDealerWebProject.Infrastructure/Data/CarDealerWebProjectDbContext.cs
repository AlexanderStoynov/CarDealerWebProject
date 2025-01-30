using CarDealerWebProject.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CarDealerWebProject.Infrastructure.Data
{
    public class CarDealerWebProjectDbContext : IdentityDbContext
    {
        public CarDealerWebProjectDbContext(DbContextOptions<CarDealerWebProjectDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<Vehicle> Vehicles { get; set; }

        public DbSet<Car> Cars { get; set; }

        public DbSet<Motorcycle> Motorcycles { get; set; }

        public DbSet<Seller> Sellers { get; set; }
    }
}
