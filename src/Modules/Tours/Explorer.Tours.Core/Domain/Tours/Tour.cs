using Explorer.BuildingBlocks.Core.Domain;
using System.Text.Json.Serialization;
using static Explorer.Tours.API.Enums.TourEnums;

namespace Explorer.Tours.Core.Domain.Tours
{
    public class Tour : Entity
    {
        [JsonPropertyName("Id")]
        public long TourId => base.Id;

        [JsonPropertyName("name")]
        public string Name { get; init; }
        [JsonPropertyName("description")]
        public string Description { get; init; }
        [JsonPropertyName("diffucult")]
        public int Difficult { get; init; }
        [JsonPropertyName("status")]
        public TourStatus Status { get; private set; }
        [JsonPropertyName("price")]
        public double Price { get; init; }
        [JsonPropertyName("points")]
        public List<Point>? Points { get; init; }
        [JsonPropertyName("tags")]
        public List<Tag>? Tags { get; init; }
        [JsonPropertyName("requiredTimes")]
        public List<RequiredTime>? RequiredTimes { get; init; }
        [JsonPropertyName("guide")]
        public Guide Guide { get; init; }
        [JsonPropertyName("length")]
        public float? Length { get; init; }
        [JsonPropertyName("publishTime")]
        public DateTime? PublishTime { get; private set; }
        [JsonPropertyName("arhiveTime")]
        public DateTime? ArhiveTime { get; private set; }

        [JsonConstructor]
        public Tour(long tourId, string name, string description, int difficult, TourStatus status, double price, Guide guide, float length, DateTime? publishTime, DateTime? arhiveTime, List<Point> points, List<Tag> tags, List<RequiredTime> requiredTimes)
        {
            Id = TourId;
            Name = name;
            Description = description;
            Difficult = difficult;
            Status = status;
            Price = price;
            List<Point> Points = points;
            List<Tag> Tags = tags;
            List<RequiredTime> RequiredTimes = requiredTimes;
            Guide = new Guide(guide.Id, guide.Name, guide.Surname, guide.Email);
            Length = length;
            PublishTime = publishTime;
            ArhiveTime = arhiveTime;
            Validate();
        }

        private void Validate()
        {
            if (string.IsNullOrEmpty(Name))
                throw new ArgumentException("Invalid name");
            if (string.IsNullOrEmpty(Description))
                throw new ArgumentException("Invalid description");
            if (Difficult <= 0)
                throw new ArgumentException("Invalid diffcult");
            if (Price < 0)
                throw new ArgumentException("Invalid price");
            if (Length < 0)
                throw new ArgumentException("Invalid Length. Length can't be less then 0!");
        }

        public void PublishTour()
        {
            if (Points.Count >= 2 && RequiredTimes.Count != 0 && Tags.Count != 0)
            {
                Status = TourStatus.Published;
                PublishTime = DateTime.Now;
                return;
            }
            throw new ArgumentException("Tour must meet all requirements!");
        }

        public void ArhiveTour()
        {
            if(Status == TourStatus.Published)
            {
                Status = TourStatus.Archived;
                ArhiveTime = DateTime.Now;
                return;
            }
            throw new ArgumentException("Tour needs to be published first!");
        }
    }
}
