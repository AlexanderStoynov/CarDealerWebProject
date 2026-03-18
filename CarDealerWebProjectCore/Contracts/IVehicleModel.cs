namespace CarDealerWebProject.Core.Contracts
{
    public interface IVehicleModel
    {
        public string Make {  get; set; }

        public string Model { get; set; }

        public decimal Price { get; set; }

        public int HorsePower { get; set; }
    }
}
