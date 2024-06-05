using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApplication1.DTO;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _config;

        public AuthController(IConfiguration config)
        {
            _config = config;
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public IActionResult Login([FromBody] AccountDTO accountDTO)
        {
            IActionResult response = Unauthorized();
            if (accountDTO.Email.Equals("user@example.com") && accountDTO.Password.Equals("string"))
            {
                var tokenString = GenerateJSONWebToken(accountDTO);
                response = Ok(tokenString);
            }
            return response;
        }

        private string GenerateJSONWebToken(AccountDTO userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new List<Claim>
            {
                
            };
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                                                  _config["Jwt:Issuer"],
                                                  claims,
                                                  expires: DateTime.Now.AddMinutes(120),
                                                  signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
