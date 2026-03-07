using System.ComponentModel.DataAnnotations;

namespace StageWise.Dtos.Teacher.Request
{
    public class DeleteTeacherRequest
    {
        [Required]
        public required int Id { get; set; }
    }
}