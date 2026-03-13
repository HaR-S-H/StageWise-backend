using System.ComponentModel.DataAnnotations;
using StageWise.Helpers.Enums;

namespace StageWise.Models
{
    public class ProjectStage
    {
        [Key]
        public int Id { get; set; }

        public int ProjectId { get; set; }
        public Project? Project { get; set; }

        [Required]
        public StageType StageType { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        // public ICollection<StageSubmission>? Submissions { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
    }

}