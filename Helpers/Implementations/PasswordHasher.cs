using Microsoft.AspNetCore.Identity;
using StageWise.Helpers.Interfaces;

namespace StageWise.Helpers.Implementations
{
   public class PasswordHasher : IPasswordHasher
{
    private readonly PasswordHasher<object> _hasher = new();

    public string HashPassword(string password)
    {
        return _hasher.HashPassword(new object(), password);
    }

    public bool VerifyPassword(string hash, string password)
    {
        var result = _hasher.VerifyHashedPassword(new object(), hash, password);
        return result == PasswordVerificationResult.Success;
    }
}
}