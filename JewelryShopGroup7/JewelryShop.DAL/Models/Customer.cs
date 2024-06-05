namespace JewelryShop.DAL.Models;

public partial class Customer
{
    public Guid CustomerId { get; set; }

    public string? Name { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Email { get; set; }

    public decimal AmountSpent { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
