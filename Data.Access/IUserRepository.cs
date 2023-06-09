using Models;
namespace Data.Access
{
    public interface IUserRepository
    {
        Task CreateUserAsync(User user);
        Task<IEnumerable<User>> GetUsersAsync();
    }
}