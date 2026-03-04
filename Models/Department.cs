using System.ComponentModel.DataAnnotations;

namespace StageWise.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public required string Name { get; set; }

        public int HodId { get; set; }
        public Hod? Hod { get; set; }
        public bool IsActive{get;set;}=true;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}