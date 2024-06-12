using Database;
using Microsoft.AspNetCore.Mvc;

namespace Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InformationController : ControllerBase
    {
        private readonly CheckoutDbContext _context;

        public InformationController(CheckoutDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            int totalProducts = _context.Products.Count();
            int totalUsers = _context.Users.Count();
            int totalPurchases = _context.Purchases.Count();
            int totalMessages = _context.Messages.Count();
            decimal totalSales = _context.Purchases.Sum(p => p.Product.Price);
            List<DateTime> purchasesDates = _context.Purchases.Select(p => p.Date_Purchased).ToList();

            return Ok(new
            {
                totalProducts,
                totalUsers,
                totalPurchases,
                totalMessages,
                totalSales,
                purchasesDates
            });
        }
    }
}