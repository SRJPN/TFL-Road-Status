using System.Net.Http;
using System.Threading.Tasks;

namespace RoadStatus.HttpClients.Interfaces
{
    public interface IRoadServiceHttpClient
    {
        Task<HttpResponseMessage> GetRoadStatusAsync(string roadId);
    }
}