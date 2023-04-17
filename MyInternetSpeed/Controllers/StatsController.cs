using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Data.Access;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MyInternetSpeed.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StatsController : Controller
    {
        private readonly IStatsRepository _statsRepository;

        public StatsController(IStatsRepository statsRepository)
        {
            _statsRepository = statsRepository;
        }
        
        [HttpGet]
        [Route("userId/history")]
        public IQueryable<double> GetHistory(string userId)
        {
            return _statsRepository.GetHistoryAsync(userId);
        }

        [HttpGet]
        [Route("ISP")]
        public IQueryable<double> GetISP(string location)
        {
            return _statsRepository.GetResultsAsync(location);
        }
    }
}