using Explorer.BuildingBlocks.Core.Domain;
using System.Text.Json.Serialization;

namespace Explorer.Tours.Core.Domain.Tours
{
    public class Point : ValueObject
    {
        public double Latitude { get; }
        public double Longitude { get; }
        public string Name { get; }
        public string Description { get; }
        public string Picture { get; }

        [JsonConstructor]
        public Point(double latitude, double longitude, string name, string description, string picture)
        {
            Latitude = latitude;
            Longitude = longitude;
            Name = name;
            Description = description;
            Picture = picture;
            Validate();
        }

        private void Validate()
        {
            if (Math.Abs(Latitude) > 90)
                throw new ArgumentException("Invalid Latitude.");
            if (Math.Abs(Longitude) > 180)
                throw new ArgumentException("Invalid Longitude.");
            if (string.IsNullOrWhiteSpace(Name))
                throw new ArgumentException("Invalid Name.");
            if (string.IsNullOrWhiteSpace(Description))
                throw new ArgumentException("Invalid Name.");
            if (string.IsNullOrWhiteSpace(Picture))
                throw new ArgumentException("Invalid Name.");
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Latitude;
            yield return Longitude;
            yield return Name;
            yield return Description;
            yield return Picture;
        }
    }
}
