using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StageWise.Models

{
    public class GroupStageProgress
{   [Key]
    public int Id { get; set; }
    [Required]
    public int StudentGroupId { get; set; }
    [ForeignKey(nameof(StudentGroupId))]
    public StudentGroup StudentGroup { get; set; } = null!;
    [Required]
    public int ProjectStageId { get; set; }
    [ForeignKey(nameof(ProjectStageId))]
    public ProjectStage ProjectStage { get; set; } = null!;

    public bool IsCompleted { get; set; }

    public DateTime? CompletedAt { get; set; }

    public List<GroupStageDocument> Documents { get; set; } = new();
}
}