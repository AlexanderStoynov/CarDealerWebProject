using CarDealerWebProject.Infrastructure.Data.Enums;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CarDealerWebProject.Infrastructure.Data.Models
{
    public class Car : Vehicle
    {
        [Required]
        [Comment("The cars body type")]
        public CarBodyType BodyType { get; set; }

    }
}
