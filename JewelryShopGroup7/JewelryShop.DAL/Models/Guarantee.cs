namespace JewelryShop.DAL.Models;

public partial class Guarantee
{
    public Guid GuaranteeId { get; set; }

    public Guid? AccountId { get; set; }

    public Guid? OrderDetailId { get; set; }

    public DateTime? DateReceive { get; set; }

    public DateTime? DateComplete { get; set; }

    public DateTime? DateBack { get; set; }

    public string? Confirm { get; set; }

    public virtual Account? Account { get; set; }

    public virtual OrderDetail? OrderDetail { get; set; }
}
