using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryShop.DTO.DTOs.Guarantee
{
    public class UpdateGuaranteeRequest
    {
        public Guid? OrderDetailId { get; set; }

        public DateTime? DateReceive { get; set; }

        public DateTime? DateComplete { get; set; }

        public DateTime? DateBack { get; set; }

        public string? Confirm { get; set; }
    }
}
