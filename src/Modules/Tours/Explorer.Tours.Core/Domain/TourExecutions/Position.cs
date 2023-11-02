using System.Text.Json.Serialization;
using Explorer.BuildingBlocks.Core.Domain;

namespace Explorer.Tours.Core.Domain.TourExecutions
{
    public class Position: ValueObject
    {
        public double Latitude { get; init; }
        public double Longitude { get; init; }
        public DateTime LastActivity { get; init; }

        [JsonConstructor]
        public Position(double lat, double lng, DateTime lastActivity)
        {
            Latitude = lat;
            Longitude = lng;
            LastActivity = lastActivity;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Latitude;
            yield return Longitude;
            yield return LastActivity;
        }
    }
}
