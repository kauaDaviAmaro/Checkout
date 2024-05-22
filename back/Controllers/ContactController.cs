using Database;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContactController
    {
        [HttpPost("/contact", Name = "Contact")]
        public Task<IActionResult> Contact(CheckoutDbContext context, [FromBody] Messages message)
        {
            context.Messages.Add(message);
            context.SaveChanges();            
            return Task.FromResult<IActionResult>(new OkResult());
        }
    }
}