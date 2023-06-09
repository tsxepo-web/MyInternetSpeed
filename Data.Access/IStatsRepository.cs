using Models.DTO;

namespace Data.Access
{
    public interface IStatsRepository
    {
        Task<List<HistoryDto>> GetHistoryAsync(string userId);
        Task<ResultDto> GetResultsAsync(string location);
    }
}