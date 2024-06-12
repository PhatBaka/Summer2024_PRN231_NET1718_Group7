using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryShop.DTO.DTOs.Account
{
    public class AccountFilter
    {
        public string? Email { get; set; }

        public string? Password { get; set; }

        public string? Status { get; set; }

        public string Role { get; set; }
    }
}
