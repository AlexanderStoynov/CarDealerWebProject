using CarDealerWebProject.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CarDealerWebProject.Infrastructure.Data
{
    public class CarDealerWebProjectDbContext : IdentityDbContext<User, ApplicationRole, Guid>
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

        public override DbSet<User> Users { get; set; }

        public DbSet<Motor> Motors { get; set; }

    }
}
