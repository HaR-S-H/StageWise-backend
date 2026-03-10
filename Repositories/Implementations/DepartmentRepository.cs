using Microsoft.EntityFrameworkCore;
using StageWise.Data;
using StageWise.Models;
using StageWise.Repositories.Interfaces;

namespace StageWise.Repositories.Implementations
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly ApplicationDbContext _context;
        public DepartmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Department?> GetByNameAsync(string Name)
        {
            return await _context.Departments.FirstOrDefaultAsync(d => d.Name == Name);
        }
        public async Task AddAsync(Department department)
        {
            await _context.Departments.AddAsync(department);

        }
        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<Department?> GetByIdAsync(int Id)
        {
            return await _context.Departments.Include(d=>d.Hod).FirstOrDefaultAsync(d => d.Id == Id);
        }
    }
}