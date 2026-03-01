using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace StageWise.Models{
public class GroupMember
{
    [Key]
    public int Id { get; set; }

    public int GroupId { get; set; }

    [ForeignKey(nameof(GroupId))]
    public Group Group { get; set; }

    public int StudentId { get; set; }

    [ForeignKey(nameof(StudentId))]
    public User Student { get; set; }
}
  
  
}

