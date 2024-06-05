using Database;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly CheckoutDbContext _context;

        public PaymentController(CheckoutDbContext context)
        {
            _context = context;
        }

        [HttpPost(Name = "AddPayment")]
        public IActionResult Create(Payment payment)
        {
            _context.Payments.Add(payment);
            _context.SaveChanges();
            return new OkObjectResult(payment);
        }

        [HttpGet(Name = "GetPayments")]
        public IActionResult Get()
        {
            return new OkObjectResult(_context.Payments);
        }

        [HttpGet("{id}", Name = "GetPaymentById")]
        public IActionResult Get(int id)
        {
            return new OkObjectResult(_context.Payments.Find(id));
        }

        [HttpPut("{id}", Name = "UpdatePayment")]
        public IActionResult Update(int id, Payment payment)
        {
            var paymentToUpdate = _context.Payments.Find(id);
            if (paymentToUpdate == null)
            {
                return new NotFoundResult();
            }

            _context.Payments.Update(payment);
            _context.SaveChanges();
            return new OkObjectResult(payment);
        }

        [HttpDelete("{id}", Name = "DeletePayment")]
        public IActionResult Delete(int id)
        {
            var payment = _context.Payments.Find(id);
            if (payment == null)
            {
                return new NotFoundResult();
            }
            _context.Payments.Remove(payment);
            _context.SaveChanges();
            return new OkResult();
        }
    }
}