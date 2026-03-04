using System.ComponentModel.DataAnnotations;

namespace StageWise.Models
{
    public class ProjectStage{
    
        [Key]
        public int Id { get; set; }
        [Required]
        public required string StageName { get; set; }
        public int Order { get; set; }
        [Required]
        public int ProjectId { get; set; }
        public Project Project { get; set; } = null!;
        public bool IsActive{get;set;}=true;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
        
    }
}