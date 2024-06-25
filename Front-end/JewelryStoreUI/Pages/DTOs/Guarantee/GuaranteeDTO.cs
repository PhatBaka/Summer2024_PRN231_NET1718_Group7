using JewelryStoreUI.Pages.Helpers;

namespace JewelryStoreUI.Pages.DTOs.Guarantee
{
    public partial class GuaranteeDTO : ResponseResult<CreateGuarantee>
    {
        public string Base64;
    }
    public partial class CreateGuarantee
    {
        public Guid? GuaranteeId { get; set; }

        public Guid? AccountId { get; set; }

        public Guid? OrderDetailId { get; set; }

        public DateTime? DateReceive { get; set; }

        public DateTime? DateComplete { get; set; }

        public DateTime? DateBack { get; set; }

        public string? Confirm { get; set; }

        //public AccountDTO? Account { get; set; }

        //public OrderDetailDTO? OrderDetail { get; set; }
    }
    public partial class UpdateGuarantee
    {
        public Guid? GuaranteeId { get; set; }

        public Guid? AccountId { get; set; }

        public Guid? OrderDetailId { get; set; }

        public DateTime? DateReceive { get; set; }

        public DateTime? DateComplete { get; set; }

        public DateTime? DateBack { get; set; }

        public string? Confirm { get; set; }

        //public AccountDTO? Account { get; set; }

        //public OrderDetailDTO? OrderDetail { get; set; }
    }

}
