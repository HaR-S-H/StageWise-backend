using System.ComponentModel.DataAnnotations;

namespace StageWise.Dtos.Admin.Request
{

    public class CreateAdminRequest
    {
        [Required]
        public required string Name { get; set; }
        [Required]
        [EmailAddress]
        public required string Email { get; set; }
        
    }
    
}