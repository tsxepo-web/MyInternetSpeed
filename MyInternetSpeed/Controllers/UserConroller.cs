using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Data.Access;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models;

namespace MyInternetSpeed.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserConroller : Controller
    {
        private readonly IUserRepository  _userRepository;

        public UserConroller(IUserRepository context)
        {
            _userRepository = context;
        }
        [HttpPost]
        public async Task<IActionResult> PostUser(User user)
        {
            await _userRepository.CreateUserAsync(user);
            return NoContent();
        }
    }
}