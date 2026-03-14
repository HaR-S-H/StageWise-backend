using StageWise.Models;

namespace StageWise.Repositories.Interfaces
{
   public interface IProjectRepository
    {
        Task AddAsync(Project project);
        Task<Project?> GetByIdAsync(int Id);
        Task<List<Project>> GetAllAsync();
        Task<List<Project>> GetProjectsByClassIdsAsync(List<int> classIds);
        // Task<List<Project>> GetProjectsByTeacherIdAsync(int teacherId);
        // Task<List<Project>> GetProjectsByDepartmentIdAsync(int departmentId);
        Task SaveAsync();
    }
}