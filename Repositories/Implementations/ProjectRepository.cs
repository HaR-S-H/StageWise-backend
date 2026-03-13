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
        public async Task<Project?> GetByIdAsync(int Id)
        {
            return await _context.Projects.FirstOrDefaultAsync(p => p.Id == Id);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}