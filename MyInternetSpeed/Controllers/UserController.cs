using Data.Access;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace MyInternetSpeed.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserRepository  _userRepository;

        public UserController(IUserRepository context)
        {
            _userRepository = context;
        }
        [HttpPost]
        public async Task<IActionResult> PostUser(User user)
        {
            await _userRepository.CreateUserAsync(user);
            return NoContent();
        }

        [HttpGet]
        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _userRepository.GetUsersAsync();
        }
    }
}