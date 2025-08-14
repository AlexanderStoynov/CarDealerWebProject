using Microsoft.AspNetCore.Identity;

namespace CarDealerWebProject.Infrastructure.Data.Models
{
    public class ApplicationRole : IdentityRole<Guid>
    {
        public ApplicationRole() : base() { }

        public ApplicationRole(string roleName) : base(roleName) { }
    }
}
