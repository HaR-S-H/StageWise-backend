using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace StageWise.Models{

public class Project
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    public int CourseId { get; set; }

    [ForeignKey(nameof(CourseId))]
    public Course Course { get; set; }

    public string? Description { get; set; }
}

}

