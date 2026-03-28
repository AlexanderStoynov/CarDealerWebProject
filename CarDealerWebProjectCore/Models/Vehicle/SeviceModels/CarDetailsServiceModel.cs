using CarDealerWebProject.Infrastructure.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace CarDealerWebProject.Core.Models.Vehicle.SeviceModels
{
    internal class CarDetailsServiceModel : VehicleDetailsServiceModel
    {
        [Required]
        [Display(Name = "Car body type")]
        public CarBodyType CarBodyType { get; set; }

        public CarDetailsServiceModel(VehicleDetailsServiceModel baseModel)
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
