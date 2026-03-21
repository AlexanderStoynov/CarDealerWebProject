namespace CarDealerWebProject.Core.Contracts.Models
{
    public interface IVehicleModel
    {
        public string Make {  get; set; }

        public string Model { get; set; }

        public decimal Price { get; set; }

    }
}
