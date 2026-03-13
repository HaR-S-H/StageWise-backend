using System.ComponentModel.DataAnnotations;

namespace StageWise.Dtos.Project.Request
{
    public class CreateProjectRequest
    {   [Required]
        public required string Name { get; set; }
        [Required]
        public required string Description { get; set; }
        [Required]
        public required int ClassId { get; set; }

    }
}