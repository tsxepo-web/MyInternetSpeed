using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;

namespace Data.Access
{
    public interface IStatsRepository
    {
        IQueryable<double> GetHistoryAsync(string userId);
        IQueryable<double> GetResultsAsync(string location);
    }
}