using StageWise.Helpers.Enums;

namespace StageWise.Dtos.Admin.Response
{
    public class GetAdminResponse
    {
        public required int Id { get; set; }
        public required string Email { get; set; }
        public required string Name { get; set; }
        public UserRole Role { get; set; } = UserRole.Admin;
    }
}