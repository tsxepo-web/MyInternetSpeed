using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Access;
using Database.Context;
using Models;

namespace Database
{
    public class StatsRepository : IStatsRepository
    {
        private readonly UserContext _context;
        public StatsRepository(UserContext context)
        {
            _context = context;
        }
        public async Task<User> GetHistoryAsync(int Id)
        {
           return await _context.Users.FindAsync(Id);
        }

        public Task<User> GetResultsAsync(string location)
        {
            throw new NotImplementedException();
        }
    }
}