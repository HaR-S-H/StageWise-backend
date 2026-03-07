using System.ComponentModel.DataAnnotations;

namespace StageWise.Dtos.Teacher.Response
{
    public class UpdateTeacherResponse
    {
        [Required]
        public bool Success { get; set; }
        public string? Message { get; set; }
    }
}