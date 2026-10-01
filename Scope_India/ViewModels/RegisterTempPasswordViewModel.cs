using System.ComponentModel.DataAnnotations;

namespace Final_project.ViewModels
{
    public class RequestTempPasswordViewModel
    {
        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;
    }
}