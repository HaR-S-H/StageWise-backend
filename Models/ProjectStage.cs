using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StageWise.Models
{
  public class ProjectStage
{
    [Key]
    public int Id { get; set; }

    public int ProjectId { get; set; }

    [ForeignKey(nameof(ProjectId))]
    public Project Project { get; set; }

    public int StageTypeId { get; set; }

    [ForeignKey(nameof(StageTypeId))]
    public StageMaster StageMaster { get; set; }

    public int StageOrder { get; set; }

    public DateTime? DueDate { get; set; }

    public bool IsActive { get; set; } = true;
}
}

