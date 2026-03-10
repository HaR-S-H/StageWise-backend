using StageWise.Models;

namespace StageWise.Repositories.Interfaces
{
    public interface ICourseRepository
    {
        Task<Course?> GetByNameAsync(string Name);
        Task AddAsync(Course course);
        Task<Course?> GetByIdAsync(int Id);
        Task<List<Course>> GetAllAsync();
        Task DeleteAsync(Course course);
        Task SaveAsync();
    }
}