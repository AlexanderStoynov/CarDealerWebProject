using System.Security.Claims;

namespace CarDealerWebProject.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static string Email(this ClaimsPrincipal user)
        {
            return user.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
