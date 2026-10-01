using Microsoft.EntityFrameworkCore;
using Scope_India.DAL;
using Scope_India.DATA.Context;

namespace Scope_India.DATA
{
    public class SqlTestimonial : ITestimonial
    {
        private readonly Scope_IndiaDbContext _db;

        public SqlTestimonial(Scope_IndiaDbContext db)
        {
            _db = db;
        }

        public async Task<List<Testimonial>> GetAllAsync() =>
            await _db.Testimonials.ToListAsync();
    }
}