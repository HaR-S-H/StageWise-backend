using System.ComponentModel.DataAnnotations;

namespace StageWise.Dtos.Teacher.Request
{
    public class UpdateTeacherRequest
    {
        [Required]
        public required int Id { get; set; }
        public string? Name { get; set; }
        public IFormFile? Avatar { get; set; }
        public string? BlockNumber { get; set; }
        public string? CabinNumber { get; set; }
        public string? ContactNumber { get; set; }

    }
}