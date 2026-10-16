using System.ComponentModel.DataAnnotations;

namespace Scope_India.DAL
{
    public class Testimonial
    {
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string StudentName { get; set; } = string.Empty;

        [Required]
        public string Message { get; set; } = string.Empty;

        public string? CourseTaken { get; set; }

        public string? Role { get; set; }          // e.g. "Software Developer"
        public string? Company { get; set; }        // e.g. "Tech Solutions"
        public string? PhotoPath { get; set; }       // e.g. "/images/testimonials/ananya.jpg"
        public int Rating { get; set; } = 5;         // star rating
    }
}