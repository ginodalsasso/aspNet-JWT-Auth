using aspNet_JWT_Auth.Entities;
using aspNet_JWT_Auth.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace aspNet_JWT_Auth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IConfiguration configuration) : ControllerBase
    {
        public static User user = new User();

        [HttpPost("register")]
        public ActionResult<User> Register(UserDto request)
        {
            var hashedPassword = new PasswordHasher<User>()
                .HashPassword(user, request.PasswordHash);

            user.Username = request.Username;
            user.PasswordHash = hashedPassword;

            return Ok(user);
        }

        [HttpPost("login")]
        public ActionResult<string> Login(UserDto request)
        {
            if (user.Username != request.Username)
            {
                return BadRequest("User not found");
            }

            var passwordVerificationResult = new PasswordHasher<User>()
                .VerifyHashedPassword(user, user.PasswordHash, request.PasswordHash);

            if (passwordVerificationResult == PasswordVerificationResult.Failed)
            {
                return BadRequest("Wrong credentials");
            }

            string token = CreateToken(user);

            return Ok(token);
        }

        private string CreateToken(User user)
        {
            // Create claims for the user (e.g., username, roles)
            var claims = new List<Claim>
            // {} = a collection of claims that will be included in the JWT token
            {
                new Claim(ClaimTypes.Name, user.Username)
            };

            // Create a symmetric security key using the secret key from configuration
            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(configuration.GetValue<string>("AppSettings:Token")!)
                );

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);

            var tokenDescriptor = new JwtSecurityToken(
                issuer: configuration.GetValue<string>("AppSettings:Issuer"),       // Issuer = the entity that issues the token
                audience: configuration.GetValue<string>("AppSettings:Audience"),   // Audience = the entity that the token is intended for
                claims: claims,                                                     // Claims = the claims associated with the token
                expires: DateTime.UtcNow.AddDays(1),                                // Expiration of the token
                signingCredentials: credentials                                     // Signing credentials to sign the token
               );

            // returns the token as a string
            return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
        }
    }
}
