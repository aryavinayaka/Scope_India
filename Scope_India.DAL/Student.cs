using Scope_India.DATA;
using System.ComponentModel.DataAnnotations;

namespace Scope_India.DAL
{
    public class Student
    {
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string FullName { get; set; } = string.Empty;

        [Required, EmailAddress, MaxLength(150)]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string PasswordHash { get; set; } = string.Empty;

        public string? TempPassword { get; set; }

        public string? PhoneNumber { get; set; }

        public string? Gender { get; set; }

        // Comma-separated hobbies (predefined + custom)
        public string? Hobbies { get; set; }

        public string? AvatarPath { get; set; }

        public int? CourseId { get; set; }
        public Course? Course { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}