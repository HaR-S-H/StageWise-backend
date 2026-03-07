using System.ComponentModel.DataAnnotations;

namespace StageWise.Dtos.Auth.Response
{
    public class LogoutResponse
    {
        [Required]
        public bool Success { get; set; }
        public string? Message { get; set; }
    }
}