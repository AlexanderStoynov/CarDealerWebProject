using CarDealerWebProject.Infrastructure.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace CarDealerWebProject.Core.Models.Vehicle.FormModels
{
    public class CarFormModel : VehicleFormModel
    {

        [Required]
        [Display(Name = "Body type")]
        public CarBodyType CarBodyType { get; set; }
    }
}
