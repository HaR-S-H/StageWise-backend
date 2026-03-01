using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using StageWise.Helpers.Enums;
namespace StageWise.Models{
public class GroupStageProgress
{
    [Key]
    public int Id { get; set; }

    public int GroupId { get; set; }

    [ForeignKey(nameof(GroupId))]
    public Group Group { get; set; }

    public int ProjectStageId { get; set; }

    [ForeignKey(nameof(ProjectStageId))]
    public ProjectStage ProjectStage { get; set; }

    public StageStatus Status { get; set; } = StageStatus.Pending;

    public DateTime StartedDate { get; set; } = DateTime.UtcNow;

    public DateTime? CompletedDate { get; set; }
}
  
  
}