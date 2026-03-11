using StageWise.Dtos.Class.Response;
using StageWise.Helpers.Enums;

namespace StageWise.Dtos.Student.Request
{
    public class CreateStudentRequest
    {
        public required string Name { get; set; }
        public required string Email { get; set; }
        public UserRole Role { get; set; }
        public required string ContactNumber { get; set; }
        public required int  ClassId { get; set; }
    }
}