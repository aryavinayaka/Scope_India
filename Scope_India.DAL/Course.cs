using System.ComponentModel.DataAnnotations;

namespace Scope_India.DAL
{
    public class Course
    {
        public int Id { get; set; }

        [Required, MaxLength(150)]
        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }

        public string? Duration { get; set; }

        public decimal Fee { get; set; }

        public ICollection<Student> Students { get; set; } = new List<Student>();
    }
}