using Scope_India.DAL;

namespace Scope_India.DATA
{
    public interface ITestimonial
    {
        Task<List<Testimonial>> GetAllAsync();
    }
}