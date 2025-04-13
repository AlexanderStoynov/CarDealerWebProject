using CarDealerWebProject.Infrastructure.Data.Models;
using CarDealerWebProject.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CarDealerWebProject.Infrastructure.Data
{
    public class CarDealerWebProjectDbContext : IdentityDbContext<ApplicationUser>
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
