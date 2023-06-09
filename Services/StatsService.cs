using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Access;
using Microsoft.Extensions.Options;
using Models;
using Models.DTO;
using MongoDB.Driver;

namespace Services
{
    public class StatsService : IStatsRepository
    {
        private readonly IMongoCollection<User> _userCollection;
        public StatsService(IMongoCollection<User> userCollection)
        {
            _userCollection = userCollection;
        }
        public Task<List<HistoryDto>> GetHistoryAsync(string userId)
        {

            var threeMonthsAgo = DateTime.UtcNow.AddMonths(-3);
            var filter = Builders<User>.Filter.Gte(x => x.Date, threeMonthsAgo);

            var result = _userCollection
                .Find(filter & Builders<User>.Filter.Eq(x => x.UserId, userId))
                .Project(x => new HistoryDto
                {
                    Date = x.Date,
                    UploadSpeed = x.UploadSpeed,
                    DownloadSpeed = x.DownloadSpeed
                }).ToListAsync();
            return result;
        }

        public async Task<ResultDto> GetResultsAsync(string location)
        {
            var result = await _userCollection.Aggregate()
                .Match(x => x.Location == location)
                .Group(x => new { x.Location, x.ISP },
                g => new
                {
                    Location = g.Key.Location,
                    ISP = g.Key.ISP,
                    UploadSpeed = g.Average(x => x.UploadSpeed),
                    DownloadSpeed = g.Average(x => x.DownloadSpeed)
                })
                .Group(x => x.Location,
                g => new ResultDto
                {
                    Location = g.Key,
                    ISPs = g.Select(x => new IspSpeedDto
                    {
                        ISP = x.ISP,
                        UploadSpeed = x.UploadSpeed,
                        DownloadSpeed = x.DownloadSpeed
                    }).ToList()
                })
                .FirstOrDefaultAsync();

            return result;
        }
    }
}