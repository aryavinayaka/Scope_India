using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Scope_India.ViewModels
{
    public class StudentViewModel
    {
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string FullName { get; set; } = string.Empty;

        [Required, EmailAddress, MaxLength(150)]
        public string Email { get; set; } = string.Empty;

        [Phone]
        public string? PhoneNumber { get; set; }

        public string? Gender { get; set; }

        public List<string> SelectedHobbies { get; set; } = new();

        public bool AddCustomHobby { get; set; }

        public string? CustomHobby { get; set; }

        public int? CourseId { get; set; }

        // File upload for avatar — saved to wwwroot/uploads
        public IFormFile? Avatar { get; set; }

        // Existing saved path, used when editing/displaying a student
        public string? AvatarPath { get; set; }
    }
}