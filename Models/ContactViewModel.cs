using System.ComponentModel.DataAnnotations;


namespace PJDu8.Models
{
    public class ContactViewModel
    {
        [Required(ErrorMessage = "Please enter your name.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter your email address")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MaxLength(500, ErrorMessage = "There is a 500 character limit.")]
        public string Message { get; set; }
    }
}