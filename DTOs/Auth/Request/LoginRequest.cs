using System.ComponentModel.DataAnnotations;
using StageWise.Helpers.Enums;

namespace StageWise.Dtos.Auth.Request
{
 public class LoginRequest
 {
  [Required]
  [EmailAddress]
  public required string Email { get; set; }

  [Required]
  public required string Password { get; set; }
  [Required]
  public UserRole Role { get; set; }
 }
}