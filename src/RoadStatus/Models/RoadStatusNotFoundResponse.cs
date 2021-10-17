namespace RoadStatus.Models
{
    public class RoadStatusNotFoundResponse : IRoadStatusResponse
    {
        public string DisplayName { get; set; }
        public string DisplayStatus()
        {
            return $"{DisplayName} is not a valid road";
        }
    }
}