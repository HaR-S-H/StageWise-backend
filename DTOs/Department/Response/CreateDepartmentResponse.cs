using System.ComponentModel.DataAnnotations;

namespace StageWise.Dtos.Department.Response
{
    public class CreateDepartmentResponse
    {
        [Required]
        public bool Success { get; set; }
        public string? Message { get; set; }

    }
}