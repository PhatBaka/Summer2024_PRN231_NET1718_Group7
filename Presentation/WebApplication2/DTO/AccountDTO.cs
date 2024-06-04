using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebApplication2.DTO
{
    public class AccountDTO
    {
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

        [JsonIgnore]
        public string? Role { get; set; }
    }
}
