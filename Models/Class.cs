using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using StageWise.Helpers.Enums;

namespace StageWise.Models

{[Index(nameof(Section), IsUnique = true)]
    public class Class
    {   [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public required string Name { get; set; }
        [Required]
        public int CourseId { get; set; }
        [ForeignKey(nameof(CourseId))]
        public Course? Course { get; set; }
        [Required]
        public required Specialization Specialization { get; set; }
        [Required]
        public required string Year { get; set; }
        [Required]
        public required  Section Section { get; set; }
        [Required]
        public  int AdvisorId { get; set; }
        [ForeignKey(nameof(AdvisorId))]
        public Teacher? Advisor { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;


    }
}