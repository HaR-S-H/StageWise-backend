using StageWise.Models;
namespace StageWise.Repositories.Interfaces
{
    public interface IStudentRepository
    {
        Task<Student?> GetByEmailAsync(string email);
    }
}