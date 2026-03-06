namespace StageWise.Services.Business.Interfaces
{
    public interface ICurrentUserService
    {
        int UserId { get; }
        string Email { get; }
        string Role { get; }
    }
}