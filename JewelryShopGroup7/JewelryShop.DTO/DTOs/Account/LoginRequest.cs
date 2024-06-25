using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryShop.DTO.DTOs.Account
{
    public class LoginRequest
    {
        [Required(ErrorMessage = "Email can not empty")]
        [EmailAddress(ErrorMessage = "Email is invalid")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password can not emtpy")]
        public string Password { get; set; }
    }
}
