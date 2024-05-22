using System.Security.Claims;
using Database;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController
    {
        public struct UserData
        {
            public string Email { get; set; }
            public string Password { get; set; }
        }

        [HttpPost("/login", Name = "Login")]
        public Task<IActionResult> Login(CheckoutDbContext context, [FromBody] UserData user)
        {
            User foundUser = context.Users.FirstOrDefault(u => u.Email == user.Email && u.Password == user.Password);
            if (foundUser == null)
            {
                return Task.FromResult<IActionResult>(new UnauthorizedResult());
            }

            return Task.FromResult<IActionResult>(new OkObjectResult(foundUser));
        }

        [HttpPost("/register", Name = "Register")]
        public async Task<IActionResult> Register(CheckoutDbContext context, [FromBody] User user)
        {
            if (context.Users.Any(u => u.Email == user.Email))
            {
                return new ConflictResult();
            }

            context.Users.Add(user);
            await context.SaveChangesAsync();

            return new OkObjectResult(user);
        }
    }
}