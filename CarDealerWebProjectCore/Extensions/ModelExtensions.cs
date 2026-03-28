using CarDealerWebProject.Core.Contracts.Models;
using System.Text.RegularExpressions;

namespace CarDealerWebProject.Core.Extensions
{
    public static class ModelExtensions
    {
        public static string GetInformation(this IVehicleModel vehicle)
        {
            string info = vehicle.Make.Replace(" ", "-") + vehicle.Model; // vehicle.MotorHorsePower + " hp"
            info = Regex.Replace(info, @"[^a-zA-Z0-9\-]", string.Empty);

            return info;
        }
    }
}
