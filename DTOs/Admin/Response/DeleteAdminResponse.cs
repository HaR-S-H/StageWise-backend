using System.ComponentModel.DataAnnotations;

namespace StageWise.Dtos.Admin.Response
{

    public class DeleteAdminResponse
    {
        [Required]
        public bool Success { get; set; }
        public string? Message { get; set; }

    }

}