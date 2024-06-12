using Checkout.DTOs;
using Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Controllers
{
    [Route("[controller]")]
    [ApiController]

    public class PurchasesController
    {
        private readonly CheckoutDbContext _context;

        public PurchasesController(CheckoutDbContext context)
        {
            _context = context;
        }

        [HttpGet(Name = "GetPurchases")]
        public IEnumerable<Purchase> Get()
        {
            return _context.Purchases
                .Include(p => p.User)
                .Include(p => p.Product)
                .Include(p => p.Address)
                .Include(p => p.Contact)
                .Include(p => p.Payment)
                .ToList();
        }

        [HttpGet("{id}", Name = "GetPurchaseById")]
        public IActionResult Get(int id)
        {
            return new OkObjectResult(_context.Purchases.Find(id));
        }

        [HttpPost(Name = "bulkCreate")]
        public IActionResult BulkCreate(PurchaseListCreateDTO purchaseListDto)
        {
            User? user = _context.Users.Find(purchaseListDto.UserId);
            Payment? payment = _context.Payments.Find(purchaseListDto.PaymentId);
            Contact? contact = _context.Contacts.Find(purchaseListDto.ContactId);
            Address? address = _context.Addresses.Find(purchaseListDto.AddressId);

            if (user == null || payment == null || contact == null || address == null)
            {
                return new BadRequestResult();
            }

            List<Purchase> purchases = new List<Purchase>();

            foreach (var purchase in purchaseListDto.Purchases)
            {
                Product? product = _context.Products.Find(purchase.ProductId);

                if (product == null)
                {
                    return new BadRequestResult();
                }

                Purchase newPurchase = new Purchase
                {
                    User = user,
                    Product = product,
                    Payment = payment,
                    Contact = contact,
                    Address = address,
                    Date_Purchased = DateTime.Now,
                    Status = Status.Pending,
                    Quantity = purchase.Quantity
                };

                purchases.Add(newPurchase);
            }

            _context.Purchases.AddRange(purchases);
            _context.SaveChanges();

            return new OkObjectResult(purchases);
        }


        [HttpDelete("{id}", Name = "DeletePurchaseById")]
        public IActionResult Delete(int id)
        {
            var purchase = _context.Purchases.Find(id);
            if (purchase == null)
            {
                return new NotFoundResult();
            }

            _context.Purchases.Remove(purchase);
            _context.SaveChanges();
            return new NoContentResult();
        }

        [HttpGet("user/{id}", Name = "GetPurchasesByUserId")]
        public IActionResult GetPurchasesByUserId(int id)
        {
            return new OkObjectResult(_context.Purchases
                .Include(p => p.User)
                .Include(p => p.Product)
                .Include(p => p.Address)
                .Include(p => p.Contact)
                .Include(p => p.Payment)
                .Where(p => p.User.Id == id)
                .ToList());
        }
    }
}
