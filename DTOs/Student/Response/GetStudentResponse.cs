using StageWise.Dtos.Class.Response;
using StageWise.Helpers.Enums;

namespace StageWise.Dtos.Student.Response
{
    public class GetStudentResponse
    {
        public required int Id{ get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public UserRole Role { get; set; }
        public required string ContactNumber { get; set; }
        public required int ClassId { get; set; }
    }
}