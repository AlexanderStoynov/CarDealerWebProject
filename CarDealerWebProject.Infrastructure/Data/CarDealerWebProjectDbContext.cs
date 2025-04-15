using CarDealerWebProject.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CarDealerWebProject.Infrastructure.Data
{
    public class CarDealerWebProjectDbContext : IdentityDbContext<User>
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

        public override DbSet<User> Users { get; set; }
    }
}
