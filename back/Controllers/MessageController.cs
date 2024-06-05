using Database;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MessageController
    {
        private readonly CheckoutDbContext _context;

        public MessageController(CheckoutDbContext context)
        {
            _context = context;
        }

        [HttpPost("/message", Name = "Message")]
        public IActionResult Create([FromBody] Messages message)
        {
            _context.Messages.Add(message);
            _context.SaveChanges();       
            return new OkObjectResult(message);
        }

        [HttpGet(Name = "GetMessages")]
        public IActionResult GetMessages()
        {
            return new OkObjectResult(_context.Messages);
        }

        [HttpGet("{id}", Name = "GetMessageById")]
        public IActionResult GetMessageById(int id)
        {
            var message = _context.Messages.Find(id);
            if (message == null)
            {
                return new NotFoundResult();
            }
            return new OkObjectResult(message);
        }

        [HttpPut("{id}", Name = "UpdateMessage")]
        public IActionResult Update(int id, Messages message)
        {
            var messageToUpdate = _context.Messages.Find(id);
            if (messageToUpdate == null)
            {
                return new NotFoundResult();
            }

            _context.Messages.Update(message);
            _context.SaveChanges();
            return new OkObjectResult(message);
        }

        [HttpDelete("{id}", Name = "DeleteMessage")]
        public IActionResult Delete(int id)
        {
            var message = _context.Messages.Find(id);
            if (message == null)
            {
                return new NotFoundResult();
            }
            _context.Messages.Remove(message);
            _context.SaveChanges();
            return new OkResult();
        }
    }
}