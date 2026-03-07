using System.ComponentModel.DataAnnotations;
using StageWise.Helpers.Enums;

namespace StageWise.Dtos.Teacher.Response
{
    public class CreateTeacherResponse
    {
        [Required]
        public bool Success { get; set; }
        public string? Message { get; set; }
    }
}