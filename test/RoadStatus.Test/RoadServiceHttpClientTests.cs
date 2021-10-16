using System.Net.Http;
using Moq;
using RoadStatus.Http;
using RoadStatus.HttpClients;
using Xunit;

namespace RoadStatus.Test
{
    public class RoadServiceHttpClientTests
    {
        private const string BASE_URL = "http://some-base-url/Road";
        private const string APP_ID = "app_id";
        private const string DEVELOPER_KEY = "your_developer_key";
        private Mock<IAppSettings> configuration;
        private Mock<IHttpClient> httpClientMock;

        public RoadServiceHttpClientTests()
        {
            httpClientMock = new Mock<IHttpClient>();
            httpClientMock.Setup(x => x.SendAsync(It.IsAny<HttpRequestMessage>())).ReturnsAsync(new HttpResponseMessage());

            configuration = new Mock<IAppSettings>();
            configuration.Setup(x => x.TFLRoadUrl).Returns(BASE_URL);
            configuration.Setup(x => x.AppId).Returns(APP_ID);
            configuration.Setup(x => x.DeveloperKey).Returns(DEVELOPER_KEY);
        }

        [Fact]
        public async void GetRoadStatusAsync_ShouldRequestRoadStatusForGivenRoadId()
        {
            var client = new RoadServiceHttpClient(httpClientMock.Object, configuration.Object);

            var response = await client.GetRoadStatusAsync("some-valid-road-id");

            httpClientMock.Verify(x => x.SendAsync(It.Is<HttpRequestMessage>(m => m.Method == HttpMethod.Get)));
            httpClientMock.Verify(x => x.SendAsync(It.Is<HttpRequestMessage>(m => m.RequestUri.AbsoluteUri == $"{BASE_URL}/some-valid-road-id?app_id={APP_ID}&app_key={DEVELOPER_KEY}")));
        }

        [Fact]
        public async void GetRoadStatusAsync_ShouldAddTokenAndAppIdAsQueryParameters()
        {
            var client = new RoadServiceHttpClient(httpClientMock.Object, configuration.Object);

            var response = await client.GetRoadStatusAsync("some-valid-road-id");

            httpClientMock.Verify(x => x.SendAsync(It.Is<HttpRequestMessage>(m => m.RequestUri.Query == $"?app_id={APP_ID}&app_key={DEVELOPER_KEY}")));
        }
    }
}
