using StageWise.Dtos.Course.Response;
using StageWise.Dtos.Teacher.Response;
using StageWise.Helpers.Enums;

namespace StageWise.Dtos.Class.Response
{
    public class GetClassResponse
    {
        public required string Name { get; set; }
        public required GetCourseResponse Course { get; set; }
        public required Specialization Specialization { get; set; }

        public required string Year { get; set; }
        public required Section Section { get; set; }

        public required GetTeacherResponse Advisor { get; set; }
    }
}