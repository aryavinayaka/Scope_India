using Microsoft.EntityFrameworkCore;
using Scope_India.DAL;
using Scope_India.DATA.Context;

namespace Scope_India.DATA
{
    public class SqlStudent : IStudent
    {
        private readonly Scope_IndiaDbContext _db;

        public SqlStudent(Scope_IndiaDbContext db)
        {
            _db = db;
        }

        public async Task<Student?> GetByIdAsync(int id) =>
            await _db.Students.Include(s => s.Course).FirstOrDefaultAsync(s => s.Id == id);

        public async Task<Student?> GetByEmailAsync(string email) =>
            await _db.Students.FirstOrDefaultAsync(s => s.Email == email);

        public async Task<List<Student>> GetAllAsync() =>
            await _db.Students.Include(s => s.Course).ToListAsync();

        public async Task InsertAsync(Student student)
        {
            _db.Students.Add(student);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateAsync(Student student)
        {
            _db.Students.Update(student);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var student = await _db.Students.FindAsync(id);
            if (student != null)
            {
                _db.Students.Remove(student);
                await _db.SaveChangesAsync();
            }
        }
    }
}