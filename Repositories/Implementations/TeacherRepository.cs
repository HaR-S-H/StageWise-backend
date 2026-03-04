using StageWise.Data;
using StageWise.Models;
using StageWise.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
namespace StageWise.Repositories.Implementations

{
    public class TeacherRepository:ITeacherRepository
    {
        private readonly ApplicationDbContext _context;

        public TeacherRepository(ApplicationDbContext context)
        {

            _context = context;
            
        }

        public async Task<Teacher?> GetByEmailAsync(string email)
        {
            return await _context.Teachers.FirstOrDefaultAsync(t=>t.Email==email);
        }
    }
}