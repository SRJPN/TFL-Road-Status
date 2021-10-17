using System.Threading.Tasks;
using RoadStatus.Models;

namespace RoadStatus.Services
{
    public interface IRoadStatusService
    {
        Task<IRoadStatusResponse> GetRoadStatusAsync(string roadId);
    }
}