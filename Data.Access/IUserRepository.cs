using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;

namespace Data.Access
{
    public interface IUserRepository
    {
        Task CreateUserAsync(User user);
        Task<IEnumerable<User>> GetUsersAsync();
    }
}