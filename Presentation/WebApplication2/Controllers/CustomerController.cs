using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Repositories;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : Controller
    {
        [HttpGet("AdminGetAccount")]
        [Authorize(Roles = "ADMIN")]
        public IActionResult AdminGetAccount() => Ok(AccountRepo.GetAccountDTOs());

        [HttpGet("CustomerGetAccount")]
        [Authorize(Roles = "CUSTOMER")]
        public IActionResult CustomerGetAccount() => Ok(AccountRepo.GetAccountDTOs());

        [HttpGet("StaffGetAccount")]
        [Authorize(Roles = "STAFF")]
        public IActionResult StaffGetAccount() => Ok(AccountRepo.GetAccountDTOs());
    }
}
