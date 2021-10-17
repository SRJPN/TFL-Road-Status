using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RoadStatus.HttpClients.Interfaces;
using RoadStatus.Models;

namespace RoadStatus.Services
{
    public class RoadStatusService : IRoadStatusService
    {
        private readonly IRoadServiceHttpClient httpClient;

        public RoadStatusService(IRoadServiceHttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IRoadStatusResponse> GetRoadStatusAsync(string roadId)
        {
            var response = await httpClient.GetRoadStatusAsync(roadId);
            return await CreateFromResponseAsync(response, roadId);
        }

        private async Task<IRoadStatusResponse> CreateFromResponseAsync(HttpResponseMessage response, string roadId)
        {
            var json = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<RoadStatusSucessResponse[]>(json);
                return result.First();
            }
            return new RoadStatusNotFoundResponse() { DisplayName = roadId };
        }
    }
}