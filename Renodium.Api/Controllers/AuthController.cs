using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Renodium.Api.Dtos;
using Renodium.Api.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Renodium.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<AppUser> _userManager;

        public AuthController(
            IConfiguration configuration,
            UserManager<AppUser> userManager)
        {
            _configuration = configuration;
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<ActionResult> Login(LoginRequest request)
        { 
            var user = await _userManager.FindByEmailAsync(request.Email);

            if (user == null)
            {
                return Unauthorized();
            }

            bool passwordCheck = await _userManager.CheckPasswordAsync(user, request.Password);

            if (!passwordCheck)
            {
                return Unauthorized();
            }

            var roles = await _userManager.GetRolesAsync(user);

            var firstRole = roles.FirstOrDefault();

            if (user.Email == null || firstRole == null)
            {
                return Unauthorized();
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, firstRole),
            };

            var jwt = _configuration.GetSection("Jwt");
            var secret = jwt["SecretKey"];

            if (secret == null)
            { 
                return StatusCode(500);
            }

            double expiryMinutes = double.Parse(jwt["ExpiryMinutes"]);

            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));

            var token = new JwtSecurityToken(
                issuer: jwt["Issuer"],
                audience: jwt["Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(expiryMinutes),
                signingCredentials: new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256)
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            Response.Cookies.Append("token", tokenString, new CookieOptions
            {
                HttpOnly = true
            });

            return Ok();
        }
    }
}
