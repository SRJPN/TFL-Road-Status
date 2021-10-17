namespace RoadStatus.Models
{
    public class RoadStatusSucessResponse : IRoadStatusResponse
    {
        public string DisplayName { get; set; }
        public string StatusSeverity { get; set; }
        public string StatusSeverityDescription { get; set; }

        public string DisplayStatus()
        {
            var result = $@"The status of the {DisplayName} is as follows
        Road Status is {StatusSeverity}
        Road Status Description is {StatusSeverityDescription}
            ";
            return result;
        }
    }
}