namespace StageWise.Helpers.Interfaces
{
    public interface IJwtService
    {
        string GenerateToken(int userId, string email, string role);
    }
}