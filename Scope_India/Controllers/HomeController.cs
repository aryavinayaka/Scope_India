using Microsoft.AspNetCore.Mvc;
using Scope_India.DATA;
using Scope_India.ViewModels;

namespace Scope_India.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICourse _courseRepo;
        private readonly ITestimonial _testimonialRepo;

        public HomeController(ICourse courseRepo, ITestimonial testimonialRepo)
        {
            _courseRepo = courseRepo;
            _testimonialRepo = testimonialRepo;
        }

        public async Task<IActionResult> Index()
        {
            var model = new HomePageViewModel
            {
                Courses = await _courseRepo.GetAllAsync(),
                Testimonials = await _testimonialRepo.GetAllAsync()
            };
            return View(model);
        }

        public async Task<IActionResult> CourseDetails(int id)
        {
            var course = await _courseRepo.GetByIdAsync(id);
            if (course == null) return NotFound();

            return View(course);
        }

        public IActionResult Privacy() => View();

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() => View();
    }
}