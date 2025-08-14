namespace CarDealerWebProject.Core.Contracts
{
    public interface IVehicleModel
    {
        public string Make {  get; set; }

        public string Model { get; set; }

        public int MotorHorsePower { get; set; }
    }
}
