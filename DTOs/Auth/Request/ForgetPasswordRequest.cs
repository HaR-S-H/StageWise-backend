using System.ComponentModel.DataAnnotations;
using StageWise.Helpers.Enums;

namespace StageWise.Dtos.Auth.Request
{
    public class ForgetPasswordRequest
    {
        [Required]
        [EmailAddress]
        public required string Email { get; set; }
    }
}