using JewelryStoreUI.Enums;

namespace JewelryStoreUI.DTOs.Accounts
{
    public class AccountResponse
    {
        public Guid AccountId { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Status { get; set; }
    }
}
