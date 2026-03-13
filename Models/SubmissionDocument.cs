using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StageWise.Models
{
    public class SubmissionDocument
    {
        [Key]
        public int Id { get; set; }

        public int SubmissionId { get; set; }
        [ForeignKey(nameof(SubmissionId))]
        public StageSubmission? Submission { get; set; }

        [Required]
        public string FileName { get; set; } = string.Empty;

        [Required]
        public string FilePath { get; set; } = string.Empty;
    }
}