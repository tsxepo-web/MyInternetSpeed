using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;
using Models.DTO;

namespace Data.Access
{
    public interface IStatsRepository
    {
        Task<List<HistoryDto>> GetHistoryAsync(string userId);
        Task<ResultDto> GetResultsAsync(string location);
    }
}