using Scope_India.DAL;

namespace Scope_India.ViewModels
{
    public class HomePageViewModel
    {
        public List<Course> Courses { get; set; } = new();
        public List<Testimonial> Testimonials { get; set; } = new();
    }
}