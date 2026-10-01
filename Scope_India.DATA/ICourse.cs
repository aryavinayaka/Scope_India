using Scope_India.DAL;

namespace Scope_India.DATA
{
    public interface ICourse
    {
        Task<List<Course>> GetAllAsync();
        Task<Course?> GetByIdAsync(int id);
    }
}