using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using StageWise.Helpers.Enums;
namespace StageWise.Models{
[Index(nameof(Email), IsUnique = true)]
[Index(nameof(ContactNumber), IsUnique = true)]
    public class Teacher
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public required string Name { get; set; }
        [Required]
        [EmailAddress]
        [MaxLength(150)]
        public required string Email { get; set; }
        [Required]
        public required string Password { get; set; }
        public UserRole Role { get; set; }=UserRole.Teacher;
        [Required]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Contact number must be exactly 10 digits")]
        public required string ContactNumber { get; set; }
        [Required]
        public required string CabinNumber { get; set; }
        [Required]
        public required string BlockNumber { get; set; }
        [Required]
        public required int DepartmentId { get; set; }
        [ForeignKey(nameof(DepartmentId))]
        public Department? Department { get; set; }
        public bool IsActive{get;set;}=true;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    }


}