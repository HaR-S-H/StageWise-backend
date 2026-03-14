using System.ComponentModel.DataAnnotations;
using StageWise.Helpers.Enums;

namespace StageWise.Dtos.Stage.Request
{
    public class CreateStageRequest
    {   [Required]
        public int ProjectId { get; set; }

        [Required]
        public StageType StageType { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
    }
}