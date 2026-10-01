using System.ComponentModel.DataAnnotations;

namespace Scope_India.ViewModels
{
    public class RegisterViewModel
    {
        [Required, MaxLength(100)]
        public string FullName { get; set; } = string.Empty;

        [Required, EmailAddress, MaxLength(150)]
        public string Email { get; set; } = string.Empty;

        [Required, DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;

        [Required, DataType(DataType.Password), Compare("Password")]
        public string ConfirmPassword { get; set; } = string.Empty;

        public List<string> SelectedHobbies { get; set; } = new();

        public bool AddCustomHobby { get; set; }

        public string? CustomHobby { get; set; }
    }
}