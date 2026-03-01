using System.ComponentModel.DataAnnotations;
using StageWise.Helpers.Enums;

namespace StageWise.Models{


public class User
{
    [Key]
    public int Id { get; set; }

    [Required, MaxLength(100)]
    public string Name { get; set; }

    [Required, EmailAddress]
    public string Email { get; set; }

    [Required]
    public string Password { get; set; }

    [Required]
    public UserRole Role { get; set; }

    [Phone]
    public string? ContactNumber { get; set; }
}
  
  
}

