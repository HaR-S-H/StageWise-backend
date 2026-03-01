using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace StageWise.Models{

public class StageDocument
{
    [Key]
    public int Id { get; set; }

    public int GroupStageProgressId { get; set; }

    [ForeignKey(nameof(GroupStageProgressId))]
    public GroupStageProgress GroupStageProgress { get; set; }

    [Required]
    public string FileUrl { get; set; }

    public string? DocumentType { get; set; }

    public DateTime UploadedAt { get; set; } = DateTime.UtcNow;
}
  
  
}