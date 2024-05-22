using Database;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpGet(Name = "GetProducts")]
        public IEnumerable<Product> Get(CheckoutDbContext context)
        {
            return context.Products.ToList();
        }

        [HttpGet("{id}", Name = "SearchProduct")]
        public Product Get(CheckoutDbContext context, int id)
        {
            return context.Products
                .FirstOrDefault(p => p.Id == id);
        }

        [Authorize]
        [HttpGet("/random", Name = "GetRandomProduct")]
        public Product GetRandom(CheckoutDbContext context)
        {
            int count = context.Products.Count();

            Random random = new Random();
            int randomIndex = random.Next(count);

            Product randomProduct = context.Products
                .Skip(randomIndex)
                .FirstOrDefault();

            return randomProduct;
        }

        [HttpPost(Name = "AddProduct")]
        public Product Add(CheckoutDbContext context, Product product)
        {
            context.Products.Add(product);
            context.SaveChanges();
            return product;
        }

    }
}