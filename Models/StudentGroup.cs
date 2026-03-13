using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StageWise.Models
{
    public class StudentGroup
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public required string Name { get; set; } 

        public int ProjectId { get; set; }
        public Project? Project { get; set; }

        public ICollection<Student>? Students { get; set; }
        public bool IsActive { get; set; } = true;
        // public ICollection<StageSubmission>? Submissions { get; set; }
        public int MentorId { get; set; }

        [ForeignKey(nameof(MentorId))]
        public Teacher? Mentor { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}