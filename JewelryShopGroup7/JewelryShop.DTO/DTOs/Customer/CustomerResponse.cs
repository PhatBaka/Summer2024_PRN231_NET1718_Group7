using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryShop.DTO.DTOs.Customer
{
    public class CustomerResponse
    {
        public Guid CustomerId { get; set; }

        public string Name { get; set; }

        public string? PhoneNumber { get; set; }

        public string? Email { get; set; }

        public decimal AmountSpent { get; set; }
    }
}
