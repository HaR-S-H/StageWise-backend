using System.ComponentModel.DataAnnotations;

namespace StageWise.Dtos.Admin.Response
{

    public class CreateAdminResponse
    {
        [Required]
        public bool Success { get; set; }
        public string? Message { get; set; }
        
    }
    
}