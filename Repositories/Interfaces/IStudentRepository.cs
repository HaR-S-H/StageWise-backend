using StageWise.Models;
namespace StageWise.Repositories.Interfaces
{
    public interface IStudentRepository
    {
        Task<Student?> GetByEmailAsync(string Email);
        Task AddAsync(Student student);
        Task<Student?> GetByIdAsync(int Id);
        Task SaveAsync();
    }
}