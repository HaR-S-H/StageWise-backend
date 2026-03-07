using System.ComponentModel.DataAnnotations;

namespace StageWise.Dtos.Hod.Request
{
    public class DeleteHodRequest
    {
       [Required]
        public required int Id { get; set; }
    }
}