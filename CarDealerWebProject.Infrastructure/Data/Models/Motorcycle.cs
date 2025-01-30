using CarDealerWebProject.Infrastructure.Data.Enums;
using Microsoft.EntityFrameworkCore;

namespace CarDealerWebProject.Infrastructure.Data.Models
{
    public class Motorcycle : Vehicle
    {
        [Comment("Motorcycle body type")]
        public MotorcycleBodyType BodyType { get; set; }
    }
}
