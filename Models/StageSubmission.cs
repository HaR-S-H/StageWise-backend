using System.ComponentModel.DataAnnotations;
using StageWise.Helpers.Enums;

namespace StageWise.Models
{
    public class StageSubmission
    {
        [Key]
        public int Id { get; set; }

        public int ProjectStageId { get; set; }
        public ProjectStage? ProjectStage { get; set; }

        public int GroupId { get; set; }
        public StudentGroup? Group { get; set; }

        public DateTime SubmittedAt { get; set; }

        public SubmissionStatus Status { get; set; } = SubmissionStatus.Pending;

        public string? Feedback { get; set; }

        public int? Rating { get; set; }

        public int? MentorId { get; set; }

        // public DateTime? FeedbackGivenAt { get; set; }

        public ICollection<SubmissionDocument>? Documents { get; set; }
    }
}