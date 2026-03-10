
using StageWise.Dtos.Hod.Response;

namespace StageWise.Dtos.Department.Response
{
    public class GetDepartmentResponse
    {

        public required int Id { get; set; }
        public required string Name { get; set; }
        public required GetHodResponse Hod { get; set; }
    }
}