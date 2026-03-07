using StageWise.Models;
namespace StageWise.Repositories.Interfaces
{
    public interface ITeacherRepository

    {
        Task<Teacher?> GetByEmailAsync(string email);
        Task<Teacher?> GetByIdAsync(int Id);
        Task AddAsync(Teacher teacher);
        Task<List<Teacher>> GetAllAsync();
        Task DeleteAsync(Teacher teacher);
        Task UpdateAsync(Teacher teacher);
        Task SaveAsync();
    }
    
}