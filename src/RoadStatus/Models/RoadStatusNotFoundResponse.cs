namespace RoadStatus.Models
{
    public class RoadStatusNotFoundResponse : IRoadStatusResponse, IErrorResponse
    {
        public string DisplayName { get; set; }
        public string DisplayStatus()
        {
            return $"{DisplayName} is not a valid road";
        }
    }
}