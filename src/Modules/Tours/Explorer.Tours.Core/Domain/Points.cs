using Explorer.BuildingBlocks.Core.Domain;

namespace Explorer.Tours.Core.Domain
{
    public class Points : Entity
    {
        public double Latitude { get; init; }
        public double Longitude { get; init; }
        public string Name { get; init; }
        public string Description { get; init; }
        public string Picture { get; init; }
        public long TourId { get; init; }

        public Points(double latitude, double longitude, string name, string description, string picture)
        {
            if (Math.Abs(latitude) > 90) throw new ArgumentException("Invalid Latitude.");
            Latitude = latitude;
            if (Math.Abs(longitude) > 180) throw new ArgumentException("Invalid Longitude.");
            Longitude = longitude;
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Invalid Name.");
            Name = name;
            if (string.IsNullOrWhiteSpace(description)) throw new ArgumentException("Invalid Name.");
            Description = description;
            if (string.IsNullOrWhiteSpace(picture)) throw new ArgumentException("Invalid Name.");
            Picture = picture;
        }
    }
}
