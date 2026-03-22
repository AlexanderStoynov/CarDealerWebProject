using CarDealerWebProject.Infrastructure.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace CarDealerWebProject.Core.Models.Vehicle.SeviceModels
{
    internal class MotorcycleDetailsServiceModel : VehicleDetailsServiceModel
    {
        [Required]
        [Display(Name = "Motorcycle body type")]
        public MotorcycleBodyType MotorcycleBodyType { get; set; }
    }
}
