using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace StageWise.Models
{

public class Group
{
    [Key]
    public int Id { get; set; }

    public int GroupNumber { get; set; }

    public int ProjectId { get; set; }

    [ForeignKey(nameof(ProjectId))]
    public Project Project { get; set; }

    public int CaptainId { get; set; }

    [ForeignKey(nameof(CaptainId))]
    public User Captain { get; set; }

    public int MentorId { get; set; }

    [ForeignKey(nameof(MentorId))]
    public User Mentor { get; set; }

    public string? GithubRepo { get; set; }

    public int? CurrentStageId { get; set; }

    [ForeignKey(nameof(CurrentStageId))]
    public ProjectStage? CurrentStage { get; set; }
}
}

