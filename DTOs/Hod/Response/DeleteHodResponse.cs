using System.ComponentModel.DataAnnotations;

namespace StageWise.Dtos.Hod.Response
{
    public class DeleteHodResponse
    {
        [Required]
        public bool Success { get; set; }
        public string? Message { get; set; }
    }
}