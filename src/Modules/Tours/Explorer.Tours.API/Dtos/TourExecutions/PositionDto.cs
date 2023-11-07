namespace Explorer.Tours.API.Dtos.TourExecutions
{
    public class PositionDto
    {
        public int TourExecutionId { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public DateTime LastActivity {get; set; }
    }
}
