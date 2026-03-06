using System.ComponentModel.DataAnnotations;
using StageWise.Helpers.Enums;

namespace StageWise.Dtos.Hod.Request
{
    public class CreateHodResponse
    {
        [Required]
        public bool Success { get; set; }
        public string? Message { get; set; }
    }
}