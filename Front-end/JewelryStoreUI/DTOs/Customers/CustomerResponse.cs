namespace JewelryStoreUI.DTOs.Customers
{
    public class CustomerResponse
    {
        public Guid CustomerId { get; set; }

        public string? Name { get; set; }

        public string? PhoneNumber { get; set; }

        public string? Email { get; set; }

        public decimal AmountSpent { get; set; }
    }
}
