using System.ComponentModel.DataAnnotations;

namespace WebApp.Model
{
    public class RegisterVM
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

    }
}