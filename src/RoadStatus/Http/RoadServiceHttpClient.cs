using System.Net.Http;
using System.Threading.Tasks;
using RoadStatus.Http.Interfaces;

namespace RoadStatus.Http
{
    public class RoadStatusHttpClient : IRoadStatusHttpClient
    {
        private readonly IHttpClient httpClient;
        private readonly IAppSettings configuration;

        public RoadStatusHttpClient(IHttpClient httpClient, IAppSettings configuration)
        {
            this.httpClient = httpClient;
            this.configuration = configuration;
        }

        public async Task<HttpResponseMessage> GetRoadStatusAsync(string roadId)
        {
            var appId = configuration.AppId;
            var developerKey = configuration.DeveloperKey;
            var url = $"{configuration.TFLRoadUrl}/{roadId}?app_id={appId}&app_key={developerKey}";
            var requestMessage = new HttpRequestMessage(HttpMethod.Get,url);

            return await httpClient.SendAsync(requestMessage);
        }
    }
}