using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StageWise.Models
{

    public class GroupStageDocument
{   [Key]
    public int Id { get; set; }
    [Required]
    public int GroupStageProgressId { get; set; }
    [ForeignKey(nameof(GroupStageProgressId))]
    public GroupStageProgress GroupStageProgress { get; set; } = null!;
    [Required]
    public string FilePath { get; set; } = null!;

    public DateTime UploadedAt { get; set; } = DateTime.UtcNow;
}
    
}

