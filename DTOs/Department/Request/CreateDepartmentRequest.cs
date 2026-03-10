using System.ComponentModel.DataAnnotations;

namespace StageWise.Dtos.Department.Request
{
    public class CreateDepartmentRequest
    {
        [Required]
        public required string Name { get; set; }
        [Required]
        public required int HodId{ get; set; }
    }
}