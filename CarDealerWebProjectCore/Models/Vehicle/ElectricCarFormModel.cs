using CarDealerWebProject.Infrastructure.Data.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CarDealerWebProject.Infrastructure.Constants.DataConstants;

namespace CarDealerWebProject.Core.Models.Vehicle
{
    public class ElectricCarFormModel : VehicleFormModel
    {
        [Required]
        [Comment("Car body type")]
        public CarBodyType CarBodyType { get; set; }

        [Required]
        [Range(ElectricCarBatteryCapacityMin, ElectricCarBatteryCapacityMax)]
        [Comment("Battery capacity")]
        public int BatteryCapacity { get; set; }
    }
}
