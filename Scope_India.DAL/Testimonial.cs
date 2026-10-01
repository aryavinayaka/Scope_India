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
    }
}