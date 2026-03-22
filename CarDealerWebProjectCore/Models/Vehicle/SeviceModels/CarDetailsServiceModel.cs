using CarDealerWebProject.Infrastructure.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace CarDealerWebProject.Core.Models.Vehicle.SeviceModels
{
    internal class CarDetailsServiceModel : VehicleDetailsServiceModel
    {
        [Required]
        [Display(Name = "Car body type")]
        public CarBodyType CarBodyType { get; set; }
    }
}
