namespace CarDealerWebProject.Core.Models.Vehicle
{
    public class VehicleDetailsViewModel 
    {
        public int Id { get; set; }

        public string Make { get; set; } = string.Empty;
         
        public string Model { get; set; } = string.Empty;

        public string VehicleImage { get; set; } = string.Empty;
    }
}
