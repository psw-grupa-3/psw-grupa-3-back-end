using Explorer.BuildingBlocks.Core.Domain;
using System.Text.Json.Serialization;

namespace Explorer.Tours.Core.Domain.Tours
{
    public class Point : ValueObject
    {
        [JsonPropertyName("Latitude")]
        public double Latitude { get; set; }
        [JsonPropertyName("Longitude")]
        public double Longitude { get; set; }
        [JsonPropertyName("Name")]
        public string Name { get; set; }
        [JsonPropertyName("Description")]
        public string Description { get; set; }
        [JsonPropertyName("Picture")]
        public string Picture { get; set; }

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
