namespace JewelryShop.DAL.Models;

public partial class OrderType
{
    public Guid OrderTypeId { get; set; }

    public string? TypeName { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
