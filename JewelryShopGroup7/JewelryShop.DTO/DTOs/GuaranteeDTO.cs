namespace JewelryShop.DTO.DTOs;

public partial class GuaranteeDTO
{
    public Guid? GuaranteeId { get; set; }

    public Guid? AccountId { get; set; }

    public Guid? OrderDetailId { get; set; }

    public DateTime? DateReceive { get; set; }

    public DateTime? DateComplete { get; set; }

    public DateTime? DateBack { get; set; }

    public string? Confirm { get; set; }

    /*public AccountDTO? Account { get; set; }*/

   /* public string AccountName {  get; set; }*/

    //public OrderDetailDTO? OrderDetail { get; set; }
}
