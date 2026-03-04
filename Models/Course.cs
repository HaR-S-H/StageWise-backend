using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StageWise.Models
{

    public class Course
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public required string Name { get; set; }
        [Required]
        public int DepartmentId { get; set; }
        [ForeignKey(nameof(DepartmentId))]
        public Department? Department { get; set; }
        public bool IsActive{get;set;}=true;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    }
    
}

