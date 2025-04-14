using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CarDealerWebProject.Infrastructure.Data.Models
{
    //[Index(nameof(Email), IsUnique = true)]
    public class User
    {
        [Key]
        [Comment("User id")]
        public int Id { get; set; }

        [Required]
        [Comment("User name")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Comment("User Identifier")]
        public string UserId { get; set; } = string.Empty;

        [Required]
        [Comment("User e-mail")]
        public string Email { get; set; } = string.Empty;

    }
}
