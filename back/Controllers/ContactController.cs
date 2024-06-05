using Database;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContactController
    {
        private readonly CheckoutDbContext _context;

        public ContactController(CheckoutDbContext context)
        {
            _context = context;
        }

        [HttpPost("/contact", Name = "AddContact")]
        public IActionResult Create([FromBody] Contact contact)
        {
            _context.Contacts.Add(contact);
            _context.SaveChanges();            
            return new OkObjectResult(contact);
        }

        [HttpGet(Name = "GetContacts")]
        public IActionResult GetContacts()
        {
            return new OkObjectResult(_context.Contacts);
        }

        [HttpGet("{id}", Name = "GetContactById")]
        public IActionResult GetContactById(int id)
        {
            var contact = _context.Contacts.Find(id);
            if (contact == null)
            {
                return new NotFoundResult();
            }
            return new OkObjectResult(contact);
        }

        [HttpPut("{id}", Name = "UpdateContact")]
        public IActionResult Update(int id, Contact contact)
        {
            var contactToUpdate = _context.Contacts.Find(id);
            if (contactToUpdate == null)
            {
                return new NotFoundResult();
            }

            _context.Contacts.Update(contact);
            _context.SaveChanges();
            return new OkObjectResult(contact);
        }

        [HttpDelete("{id}", Name = "DeleteContact")]
        public IActionResult Delete(int id)
        {
            var contact = _context.Contacts.Find(id);
            if (contact == null)
            {
                return new NotFoundResult();
            }
            _context.Contacts.Remove(contact);
            _context.SaveChanges();
            return new OkResult();
        }
        
    }
}