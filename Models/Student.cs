using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using StageWise.Helpers.Enums;

namespace StageWise.Models{

[Index(nameof(Email), IsUnique = true)]
[Index(nameof(ContactNumber), IsUnique = true)]
public class Student
{
    [Key]
    public int Id { get; set; }

    [Required]
        [MaxLength(100)]
        public required string Name { get; set; }
        public string? Avatar{ get; set; }

    [Required]
    [EmailAddress]
    [MaxLength(150)]
    public required string Email { get; set; }

    [Required]
    public required string Password { get; set; }
    public UserRole Role { get; set; }=UserRole.Student;
    [Required]
    [Phone]
    [MaxLength(10)]
    [MinLength(10)]
    public required string ContactNumber { get; set; }
    public int ClassId { get; set; }

    [ForeignKey(nameof(ClassId))]
     public Class? Class { get; set; }
    public bool IsActive{get;set;}=true;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
}

