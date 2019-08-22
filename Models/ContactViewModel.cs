using System.ComponentModel.DataAnnotations;


namespace PJDu8.Models
{
    public class ContactViewModel
    {
        [Required(ErrorMessage = "Please enter your name.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter your email address.")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MaxLength(1000, ErrorMessage = "There is a 1000 character limit. Try to reduce your message!")]
        public string Message { get; set; }
    }
}