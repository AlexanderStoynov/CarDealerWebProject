using CarDealerWebProject.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealerWebProject.Core.Models.Vehicle
{
    public class VehicleDetailsViewModel 
    {
        public int Id { get; set; }

        public string Make { get; set; } = string.Empty;
         
        public string Model { get; set; } = string.Empty;

        public string VehicleImage { get; set; } = string.Empty;
    }
}
