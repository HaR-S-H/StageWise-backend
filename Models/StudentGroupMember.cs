using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StageWise.Models
{

    public class StudentGroupMember
{   [Key]
    public int Id { get; set; }
    [Required]
    public int StudentId { get; set; }
    [ForeignKey(nameof(StudentId))]
    public Student Student { get; set; } = null!;
    [Required]
    public int StudentGroupId { get; set; }
    [ForeignKey(nameof(StudentGroupId))]
    public StudentGroup StudentGroup { get; set; } = null!;

    public DateTime JoinedAt { get; set; } = DateTime.UtcNow;

    public bool IsLeader { get; set; }
}
    
}

