using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using StageWise.Helpers.Enums;
namespace StageWise.Models
{
[Index(nameof(Email), IsUnique = true)]
    public class Admin
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public required string Name { get; set; }
        [Required]
        [EmailAddress]
        [MaxLength(150)]
        public required string Email{get; set; }
        [Required]
        public required string Password { get; set; }

        public UserRole Role{get; set; }= UserRole.Admin;
        public bool IsActive{get;set;}=true;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }

}