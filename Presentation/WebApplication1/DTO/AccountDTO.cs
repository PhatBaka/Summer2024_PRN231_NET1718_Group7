using System.ComponentModel.DataAnnotations;

namespace WebApplication1.DTO
{
    public class AccountDTO
    {
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
