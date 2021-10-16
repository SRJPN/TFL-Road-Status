using System.Net.Http;
using RoadStatus.HttpClients.Interfaces;
using System.Threading.Tasks;
using RoadStatus.Http;

namespace RoadStatus.HttpClients
{
    public class RoadServiceHttpClient : IRoadServiceHttpClient
    {
        private readonly IHttpClient httpClient;
        private readonly IAppSettings configuration;

        public RoadServiceHttpClient(IHttpClient httpClient, IAppSettings configuration)
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