using Database;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AddressController : ControllerBase
    {
        private readonly CheckoutDbContext _context;

        public AddressController(CheckoutDbContext context)
        {
            _context = context;
        }

        [HttpPost(Name = "AddAddress")]
        public IActionResult Create(Address address)
        {
            _context.Addresses.Add(address);
            _context.SaveChanges();
            return new OkObjectResult(address);
        }

        [HttpGet(Name = "GetAddresses")]
        public IActionResult GetAddresses()
        {
            return new OkObjectResult(_context.Addresses);
        }

        [HttpGet("{id}", Name = "GetAddressById")]
        public IActionResult GetAddressById(int id)
        {
            var address = _context.Addresses.Find(id);
            if (address == null)
            {
                return new NotFoundResult();
            }
            return new OkObjectResult(address);
        }

        [HttpPut("{id}", Name = "UpdateAddress")]
        public IActionResult Update(int id, Address address)
        {
            var addressToUpdate = _context.Addresses.Find(id);
            if (addressToUpdate == null)
            {
                return new NotFoundResult();
            }

            _context.Addresses.Update(address);
            _context.SaveChanges();
            return new OkObjectResult(address);
        }

        [HttpDelete("{id}", Name = "DeleteAddress")]
        public IActionResult Delete(int id)
        {
            var address = _context.Addresses.Find(id);
            if (address == null)
            {
                return new NotFoundResult();
            }
            _context.Addresses.Remove(address);
            _context.SaveChanges();
            return new OkResult();
        }
    }
}