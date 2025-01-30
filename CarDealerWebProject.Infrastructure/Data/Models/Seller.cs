using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CarDealerWebProject.Infrastructure.Data.Models
{
    public class Seller
    {
        [Key]
        [Comment("Seller id")]
        public int Id { get; set; }

        [Required]
        [Comment("Seller name")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Comment("Seller e-mail")]
        public string Email { get; set; } = string.Empty;
    }
}
