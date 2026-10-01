using Microsoft.EntityFrameworkCore;
using Scope_India.DAL;
using Scope_India.DATA.Context;

namespace Scope_India.DATA
{
    public class SqlCourse : ICourse
    {
        private readonly Scope_IndiaDbContext _db;

        public SqlCourse(Scope_IndiaDbContext db)
        {
            _db = db;
        }

        public async Task<List<Course>> GetAllAsync() =>
            await _db.Courses.ToListAsync();

        public async Task<Course?> GetByIdAsync(int id) =>
            await _db.Courses.FindAsync(id);
    }
}