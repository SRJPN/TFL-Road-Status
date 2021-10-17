using System.Net.Http;
using System.Threading.Tasks;

namespace RoadStatus.Http
{
    public class HttpClientWrapper : IHttpClient
    {
        private readonly HttpClient _httpClient;
        public HttpClientWrapper(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request)
        {
            return await _httpClient.SendAsync(request);
        }
    }
}