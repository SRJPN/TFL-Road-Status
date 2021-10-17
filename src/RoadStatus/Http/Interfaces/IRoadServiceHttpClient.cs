using System.Net.Http;
using System.Threading.Tasks;

namespace RoadStatus.Http.Interfaces
{
    public interface IRoadStatusHttpClient
    {
        Task<HttpResponseMessage> GetRoadStatusAsync(string roadId);
    }
}