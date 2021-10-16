namespace RoadStatus
{
    public interface IAppSettings
    {
        string TFLRoadUrl { get; }
        string AppId { get; set; }
        string DeveloperKey { get; set; }
    }
}