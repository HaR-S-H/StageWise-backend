using StageWise.Dtos.Department.Response;

namespace StageWise.Dtos.Course.Response
{
    public class GetCourseResponse
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
        public required GetDepartmentResponse Department{ get; set; }
    }
}