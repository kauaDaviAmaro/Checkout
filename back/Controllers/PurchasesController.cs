using Database;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Controllers
{
    [Route("[controller]")]
    [ApiController]

    public class PurchasesController
    {
        // [Authorize]
        // [HttpGet("{id}", Name = "GetPurchase")]
        // public IEnumerable<Purchase> Get(CheckoutDbContext context, int id)
        // {
        //     IEnumerable<Purchase> purchases = context.Purchase.Include(p => p.Product)
        //         .Include(u => u.User).ToList();
                
        //     return purchases;
        // }

        [HttpPost(Name = "AddPurchase")]
        public Purchase Add(CheckoutDbContext context, [FromForm] int productId, [FromForm] int userId, [FromForm] int quantity)
        {
            Purchase purchase = new Purchase
            {
                Product = context.Products.Where(p => p.Id == productId).FirstOrDefault(),
                User = context.Users.Where(u => u.Id == userId).FirstOrDefault(),
                Quantity = quantity,
                Date_Purchased = DateTime.Now
            };
            context.Purchase.Add(purchase);
            context.SaveChanges();
            return purchase;
        }
    }
}