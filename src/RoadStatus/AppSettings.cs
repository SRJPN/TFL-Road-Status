using System.Diagnostics.CodeAnalysis;

namespace RoadStatus
{
    [ExcludeFromCodeCoverage]
    public class AppSettings : IAppSettings
    {
        public string TFLBaseUrl { get; set; }
        public string TFLRoadUrl => $"{TFLBaseUrl}/Road";

        public string AppId { get; set; }
        public string DeveloperKey { get; set; }
    }
}