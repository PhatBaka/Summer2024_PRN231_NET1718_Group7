using WebApplication2.DTO;
using WebApplication2.Enum;

namespace WebApplication2.Repositories
{
    public class AccountRepo
    { 
        public static List<AccountDTO> GetAccountDTOs()
        {
            return new()
            {
                new AccountDTO
                {
                    Email = "admin@example.com",
                    Password = "string",
                    Role = RoleEnum.ADMIN.ToString()
                },
                new AccountDTO
                {
                    Email = "staff@example.com",
                    Password = "string",
                    Role = RoleEnum.STAFF.ToString()
                },
                new AccountDTO
                {
                    Email = "customer@example.com",
                    Password = "string",
                    Role = RoleEnum.CUSTOMER.ToString()
                }
            };
        }

        public static AccountDTO Login(string email, string password)
        {
            return GetAccountDTOs().FirstOrDefault(x => x.Email == email && x.Password == password);
        }
    }
}
