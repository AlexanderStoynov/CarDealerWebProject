using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealerWebProject.Core.Models.Home
{
    public class VehicleIndexServiceModel
    {
        public int Id { get; set; }

        public string Make { get; set; } = string.Empty;
        
        public string Model { get; set; } = string.Empty;

        public List<string> VehicleImages { get; set; } = new List<string>();

    }
}
