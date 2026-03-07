using System.ComponentModel.DataAnnotations;
using StageWise.Helpers.Enums;

namespace StageWise.Dtos.Teacher.Request
{
    public class CreateTeacherRequest
    {
        [Required]
        public required string Name { get; set; }
        [EmailAddress]
        [Required]
        public required string Email { get; set; }
        public string? Avatar { get; set; }
        [Required]
        [MinLength(10)]
        [MaxLength(10)]
        public required string ContactNumber { get; set; }
        [Required]
        public required string CabinNumber { get; set; }
        [Required]
        public required string BlockNumber { get; set; }
    }
}