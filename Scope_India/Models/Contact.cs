using System.ComponentModel.DataAnnotations;

namespace Scope_India.Models
{
    public class Contact
    {
        [Required(ErrorMessage = "Please enter your Name")]
        [DataType(DataType.Text)]
        [StringLength(100)]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Please enter your Email address")]
        [DataType(DataType.EmailAddress)]
        public string? EmailAddress { get; set; }

        [Required(ErrorMessage = "Enter a Subject")]
        [DataType(DataType.Text)]
        [StringLength(200)]
        public string? Subject { get; set; }

        [DataType(DataType.Text)]
        [StringLength(500)]
        public string? Message { get; set; }

        [Required(ErrorMessage = "Please enter your Phone Number")]
        [DataType(DataType.PhoneNumber)]

        public string? PhoneNumber { get; set; }
    }
}
