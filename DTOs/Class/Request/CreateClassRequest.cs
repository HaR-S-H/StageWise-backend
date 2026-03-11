using System.ComponentModel.DataAnnotations;
using StageWise.Helpers.Enums;

namespace StageWise.Dtos.Class.Request
{
    public class CreateClassRequest
    {
        [Required]
        [MaxLength(100)]
        public required string Name { get; set; }
        [Required]
        public int CourseId { get; set; }
        [Required]
        public required Specialization Specialization { get; set; }
        [Required]
        public required string Year { get; set; }
        [Required]
        public required Section Section { get; set; }
        [Required]
        public int AdvisorId { get; set; }
    }
}