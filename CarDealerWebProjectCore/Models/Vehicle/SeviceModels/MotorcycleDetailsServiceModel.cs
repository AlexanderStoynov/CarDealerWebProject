using CarDealerWebProject.Infrastructure.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace CarDealerWebProject.Core.Models.Vehicle.SeviceModels
{
    internal class MotorcycleDetailsServiceModel : VehicleDetailsServiceModel
    {
        [Required]
        [Display(Name = "Motorcycle body type")]
        public MotorcycleBodyType MotorcycleBodyType { get; set; }

        public MotorcycleDetailsServiceModel(VehicleDetailsServiceModel baseModel) 
        {
            Id = baseModel.Id;
            Make = baseModel.Make;
            Model = baseModel.Model;
            Color = baseModel.Color;
            Transmission = baseModel.Transmission;
            ManufacturingDate = baseModel.ManufacturingDate;
            Price = baseModel.Price;
            Mileage = baseModel.Mileage;
            Motors = baseModel.Motors;
            Description = baseModel.Description;
            VehicleImages = baseModel.VehicleImages;
            IsSold = baseModel.IsSold;
            VehicleType = baseModel.VehicleType;
        }
    }
}
