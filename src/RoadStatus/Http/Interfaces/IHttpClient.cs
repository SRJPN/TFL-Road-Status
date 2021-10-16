using System.Net.Http;
using System.Threading.Tasks;

namespace RoadStatus.Http
{
    public interface IHttpClient
    {
        Task<HttpResponseMessage> SendAsync(HttpRequestMessage request);
    }
}