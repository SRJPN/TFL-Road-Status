using System.Net;
using System.Net.Http;
using Moq;
using RoadStatus.Http.Interfaces;
using RoadStatus.Models;
using RoadStatus.Services;
using Xunit;

namespace RoadStatus.Test.Services
{
    public class RoadStatusServiceTests
    {
        private Mock<IRoadStatusHttpClient> clientMock;

        public RoadStatusServiceTests()
        {
            clientMock = new Mock<IRoadStatusHttpClient>();
        }

        [Fact]
        public async void GetRoadStatusAsync_ShouldReturnSucessRoadStatusResponseOnSucessResponseFromClient()
        {
            var content = @"[
                                {
                                    ""displayName"": ""A2"",
                                    ""statusSeverity"": ""Good"",
                                    ""statusSeverityDescription"": ""No Exceptional Delays""
                                }
                            ]";
            var httpResponse = new HttpResponseMessage(HttpStatusCode.OK);
            httpResponse.Content = new StringContent(content);
            clientMock.Setup(x => x.GetRoadStatusAsync(It.IsAny<string>())).ReturnsAsync(httpResponse);

            var service = new RoadStatusService(clientMock.Object);

            var roadStatusResponse = await service.GetRoadStatusAsync("some-valid-road-id");

            Assert.IsType<RoadStatusSucessResponse>(roadStatusResponse);
            Assert.Contains("The status of the A2 is as follows", roadStatusResponse.DisplayStatus());
            Assert.Contains("Road Status is Good", roadStatusResponse.DisplayStatus());
            Assert.Contains("Road Status Description is No Exceptional Delays", roadStatusResponse.DisplayStatus());
        }

        [Fact]
        public async void GetRoadStatusAsync_ShouldReturnNotFoundRoadStatusResponseErrorResponseFromClient()
        {
            var httpResponse = new HttpResponseMessage(HttpStatusCode.NotFound);
            clientMock.Setup(x => x.GetRoadStatusAsync(It.IsAny<string>())).ReturnsAsync(httpResponse);

            var service = new RoadStatusService(clientMock.Object);

            var roadStatusResponse = await service.GetRoadStatusAsync("some-valid-road-id");

            Assert.IsType<RoadStatusNotFoundResponse>(roadStatusResponse);
            Assert.Contains("some-valid-road-id is not a valid road", roadStatusResponse.DisplayStatus());
        }
    }
}