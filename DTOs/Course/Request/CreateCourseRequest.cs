using System.ComponentModel.DataAnnotations;

namespace StageWise.Dtos.Course.Request
{
    public class CreateCourseRequest
    {
        [Required]
        public required string Name { get; set; }
        [Required]
        public int DepartmentId { get; set; }
    }
}