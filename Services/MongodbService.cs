using Data.Access;
using Models;
using MongoDB.Driver;

namespace Services
{
    public class MongodbService : IUserRepository
    {
        private readonly IMongoCollection<User> _userCollection;
        public MongodbService(IMongoCollection<User> userCollection)
        {
            _userCollection = userCollection;
        }
        public async Task CreateUserAsync(User user)
        {
            await _userCollection.InsertOneAsync(user);
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await _userCollection.Find(_ => true).ToListAsync();
        }
    }
}