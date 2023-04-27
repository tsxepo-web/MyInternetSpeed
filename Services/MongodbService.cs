using Data.Access;
using Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Models.DTO;

namespace Services
{
    public class MongodbService : IUserRepository
    {
        private readonly IMongoCollection<User> _userCollection;
        public MongodbService(IOptions<NetworkSpeedDbSettings> userDatabaseSettings)
        {
            var mongoClient  = new MongoClient(userDatabaseSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(userDatabaseSettings.Value.DatabaseName);
            _userCollection = mongoDatabase.GetCollection<User>(userDatabaseSettings.Value.UserCollectionName);
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