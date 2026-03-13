namespace StageWise.Dtos.Project.Request
{
    public class CreateProjectRequest
    {
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required int ClassId { get; set; }
        
    }
}