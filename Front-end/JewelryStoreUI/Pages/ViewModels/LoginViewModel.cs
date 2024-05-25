using System.ComponentModel.DataAnnotations;

namespace JewelryStoreUI.Pages.ViewModels
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "Email is empty")]
        [EmailAddress(ErrorMessage = "Email is invalid")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is empty")]
        public string Password { get; set; }
    }
}
