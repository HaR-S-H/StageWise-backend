using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StageWise.Models
{
    public class StudentGroup
    
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public required string Name { get; set; }
        [Required]
        public int MentorId { get; set; }

        [ForeignKey(nameof(MentorId))] 
        public Teacher Mentor { get; set; } = null!;
        [Required]
        public int ProjectId { get; set; }
        [ForeignKey(nameof(ProjectId))]
        public Project Project { get; set; } = null!;
       
         public List<StudentGroupMember> Members { get; set; } = new();

         public List<GroupStageProgress> StageProgress { get; set; } = new();
        public bool IsActive{get;set;}=true;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}