using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealerWebProject.Core.Contracts
{
    public interface IVehicleModel
    {
        public string Make {  get; set; }

        public string Model { get; set; }

        public int MotorHorsePower { get; set; }
    }
}
