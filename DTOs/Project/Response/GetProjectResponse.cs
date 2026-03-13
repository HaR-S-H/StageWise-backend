namespace StageWise.Dtos.Project.Response
{
    public class GetProjectResponse
    {
        public int Id { get; set; }

        public required string Name { get; set; }

        public string? Description { get; set; }

        public int ClassId { get; set; }

    }
}