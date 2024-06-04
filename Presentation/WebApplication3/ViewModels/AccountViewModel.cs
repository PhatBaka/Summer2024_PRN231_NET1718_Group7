using System.ComponentModel.DataAnnotations;

namespace WebApplication3.DTO
{
    public class AccountViewModel
    {
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
