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
        public IQueryable<double> GetHistoryAsync(string userId)
        {
            DateTime oneMonthAgo = DateTime.Now.AddMonths(-1);
            DateTime today = DateTime.Now;

            var history = _context.Users
                .Where(r => r.Date >= oneMonthAgo && r.Date <= today)
                .Select(r => r.DownloadSpeed);
           return history;
        }

        public IQueryable<double> GetResultsAsync(string location)
        {
            var results = _context.Users
                .Where(r => r.Location == location && r.DownloadSpeed == r.DownloadSpeed)
                .Select(r => r.DownloadSpeed);
                return results;
        }
    }
}