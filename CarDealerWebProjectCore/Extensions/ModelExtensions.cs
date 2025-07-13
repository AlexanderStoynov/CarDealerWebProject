using CarDealerWebProject.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CarDealerWebProject.Core.Extensions
{
    public static class ModelExtensions
    {
        public static string GetInformation(this IVehicleModel vehicle)
        {
            string info = vehicle.Make.Replace(" ", "-") + vehicle.Model + vehicle.MotorHorsePower + " hp";
            info = Regex.Replace(info, @"[^a-zA-Z0-9\-]", string.Empty);

            return info;
        }
    }
}
