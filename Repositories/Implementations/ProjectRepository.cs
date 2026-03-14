using StageWise.Data;
using StageWise.Models;
using StageWise.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
namespace StageWise.Repositories.Implementations
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly ApplicationDbContext _context;
        public ProjectRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Project project)
        {
            await _context.Projects.AddAsync(project);
        }

        public async Task DeleteAsync(Project project)
        {
            _context.Projects.Remove(project);
        }

        public Task<List<Project>> GetAllAsync()
        {
            return _context.Projects.ToListAsync();
        }

        public async Task<Project?> GetByIdAsync(int Id)
        {
            return await _context.Projects.FirstOrDefaultAsync(p => p.Id == Id);
        }
        public async Task<List<Project>> GetProjectsByClassIdsAsync(List<int> classIds)
        {
            return await _context.Projects
                .Where(p => classIds.Contains(p.ClassId))
                .ToListAsync();
        }
        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}