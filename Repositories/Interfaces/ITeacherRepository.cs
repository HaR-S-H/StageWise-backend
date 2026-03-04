using StageWise.Models;
namespace StageWise.Repositories.Interfaces
{
    public interface ITeacherRepository

    {
        Task<Teacher?> GetByEmailAsync(string email);
    }
    
}