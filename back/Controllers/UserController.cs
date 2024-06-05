using Checkout.DTOs;
using Database;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController
    {
        private readonly CheckoutDbContext _context;

        public UserController(CheckoutDbContext context)
        {
            _context = context;
        }

        [HttpGet(Name = "GetUsers")]
        public IActionResult GetUsers(string? searchName, string? searchEmail, int? pageNumber = 0, int? pageSize = 10)
        {
            IEnumerable<User> usersQuery = _context.Users;

            if (!string.IsNullOrWhiteSpace(searchName))
            {
                usersQuery = usersQuery.Where(u => u.FirstName.Contains(searchName) || u.LastName.Contains(searchName));
            }

            if (!string.IsNullOrWhiteSpace(searchEmail))
            {
                usersQuery = usersQuery.Where(u => u.Email.Contains(searchEmail));
            }

            int currentPageNumber = pageNumber ?? 0;
            int pageSizeToUse = pageSize ?? 10;
            int totalUsersCount = usersQuery.Count();
            int totalPagesCount = (int)Math.Ceiling((double)totalUsersCount / pageSizeToUse);

            var paginatedUsers = usersQuery
                .Skip(currentPageNumber * pageSizeToUse)
                .Take(pageSizeToUse)
                .Select(u => new
                {
                    u.Id,
                    u.FirstName,
                    u.LastName,
                    u.Phone,
                    u.Email,
                    u.CPF
                });

            return new OkObjectResult(new
            {
                Users = paginatedUsers,
                TotalUsersCount = totalUsersCount,
                TotalUsersPerPage = paginatedUsers.Count(),
                TotalPagesCount = totalPagesCount
            });
        }

        [HttpPost("/login", Name = "Login")]
        public Task<IActionResult> Login(CheckoutDbContext context, [FromBody] UserLoginDTO user)
        {
            User? foundUser = context.Users.FirstOrDefault(u => u.Email == user.Email && u.Password == user.Password);
            if (foundUser == null)
            {
                return Task.FromResult<IActionResult>(new UnauthorizedResult());
            }

            return Task.FromResult<IActionResult>(new OkObjectResult(new
            {
                foundUser.Id,
                foundUser.FirstName,
                foundUser.LastName,
                foundUser.Phone,
                foundUser.Email,
                foundUser.CPF
            }));
        }

        [HttpPost("/register", Name = "Register")]
        public async Task<IActionResult> Register(CheckoutDbContext context, [FromBody] User user)
        {
            if (context.Users.Any(u => u.Email == user.Email))
            {
                return new ConflictResult();
            }

            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();

            return new OkObjectResult(new
            {
                user.Id,
                user.FirstName,
                user.LastName,
                user.Phone,
                user.Email,
                user.CPF
            });
        }

        [HttpPut("/edit", Name = "Edit")]
        public async Task<IActionResult> Edit(CheckoutDbContext context, [FromBody] UserUpdateDTO user)
        {
            User? foundUser = context.Users.FirstOrDefault(u => u.Id == user.Id);
            if (foundUser == null)
            {
                return new NotFoundResult();
            }

            foundUser.FirstName = user.FirstName;
            foundUser.LastName = user.LastName;
            foundUser.Phone = user.Phone;
            foundUser.Email = user.Email;
            foundUser.CPF = user.Cpf;

            await context.SaveChangesAsync();
            return new OkObjectResult(new
            {
                foundUser.Id,
                foundUser.FirstName,
                foundUser.LastName,
                foundUser.Phone,
                foundUser.Email,
                foundUser.CPF
            });
        }

        [HttpPost("/change-password", Name = "ChangePassword")]
        public async Task<IActionResult> ChangePassword(CheckoutDbContext context, [FromBody] ChangePasswordRequest request)
        {
            User? user = context.Users.FirstOrDefault(u => u.Id == request.UserId);
            if (user == null)
            {
                return new NotFoundResult();
            }

            if (user.Password != request.OldPassword)
            {
                return new BadRequestResult();
            }

            user.Password = request.NewPassword;
            await context.SaveChangesAsync();
            return new OkResult();
        }

        public class ChangePasswordRequest
        {
            public int UserId { get; set; }
            public required string OldPassword { get; set; }
            public required string NewPassword { get; set; }
        }
    }
}