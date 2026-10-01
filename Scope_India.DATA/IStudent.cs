using Scope_India.DAL;

namespace Scope_India.DATA
{
    public interface IStudent
    {
        Task<Student?> GetByIdAsync(int id);
        Task<Student?> GetByEmailAsync(string email);
        Task<List<Student>> GetAllAsync();
        Task InsertAsync(Student student);
        Task UpdateAsync(Student student);
        Task DeleteAsync(int id);
    }
}