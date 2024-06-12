using JewelryShop.DTO.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryShop.DTO.DTOs.Account
{
    public class UpdateAccountRequest
    {
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
    }
}
