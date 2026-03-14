using StageWise.Data;
using StageWise.Models;
using StageWise.Repositories.Interfaces;

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

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}