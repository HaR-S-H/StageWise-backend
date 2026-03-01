using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StageWise.Models{

public class Course
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    public int DepartmentId { get; set; }

    [ForeignKey(nameof(DepartmentId))]
    public Department Department { get; set; }

    public string? Specialization { get; set; }

    public string? Section { get; set; }

    public int AdvisorId { get; set; }

    [ForeignKey(nameof(AdvisorId))]
    public User Advisor { get; set; }

    public int Year { get; set; }

    public int TotalStudents { get; set; }
}
}