using StageWise.Data;
using StageWise.Models;
using StageWise.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
namespace StageWise.Repositories.Implementations
{
    public class StageRepository : IStageRepository
    {
        private readonly ApplicationDbContext _context;

        public StageRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(ProjectStage stage)
        {
            await _context.ProjectStages.AddAsync(stage);
        }

        public async Task DeleteAsync(ProjectStage stage)
        {
           _context.ProjectStages.Remove(stage);
        }

        public Task<ProjectStage?> GetByIdAsync(int id)
        {
           return _context.ProjectStages.FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}