using Checkout.DTOs;
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
        private readonly CheckoutDbContext _context;

        public ProductController(CheckoutDbContext context)
        {
            _context = context;
        }

        [HttpGet(Name = "GetProducts")]
        public IActionResult GetProducts(string? searchQuery = null, int? pageNumber = 0, int? pageSize = 10, string? sort = null)
        {
            IEnumerable<Product> products = _context.Products;
            int totalProducts = products.Count();

            if (!string.IsNullOrWhiteSpace(searchQuery))
            {
                products = products.Where(p => p.Title.Contains(searchQuery, StringComparison.OrdinalIgnoreCase));
            }

            if (!string.IsNullOrWhiteSpace(sort))
            {
                switch (sort)
                {
                    case "title":
                        products = products.OrderBy(p => p.Title);
                        break;
                    case "rating":
                        products = products.OrderByDescending(p => p.Rating);
                        break;
                    case "highestPrice":
                        products = products.OrderByDescending(p => p.Price);
                        break;
                    case "lowestPrice":
                        products = products.OrderBy(p => p.Price);
                        break;
                    default:
                        products = products.OrderBy(p => p.Id);
                        break;
                }
            }

            int pageNumberToUse = pageNumber ?? 0;
            int pageSizeToUse = pageSize ?? 10;
            int totalProductsPerPage = products.Count();

            IEnumerable<Product> paginatedProducts = products
                .Skip(pageNumberToUse * pageSizeToUse)
                .Take(pageSizeToUse);

            return new OkObjectResult(new
            {
                Products = paginatedProducts,
                TotalCount = totalProducts,
                PageNumber = pageNumberToUse + 1,
                PageSize = pageSizeToUse,
                TotalPages = (int)Math.Ceiling((double)totalProductsPerPage / pageSizeToUse),
                TotalProducts = totalProducts
            });
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