using Explorer.BuildingBlocks.Core.Domain;

namespace Explorer.Tours.Core.Domain
{
    public class Tour : Entity
    {
        public string Name { get; init; }
        public string Description { get; init; }
        public int Difficult { get; init; }
        public string? Tags { get; init; }
        public TourStatus Status { get; init; }
        public double Price { get; init; }
        public int AuthorId { get; init; }

        public Tour(string name, string description, int difficult, string? tags, TourStatus status, double price, int authorId)
        {
            Name = name;
            Description = description;
            Difficult = difficult;
            Tags = tags;
            Status = status;
            Price = price;
            AuthorId = authorId;
            Validate();
        }

        private void Validate()
        {
            if(string.IsNullOrEmpty(Name)) throw new ArgumentException("Invalid name");
            if(string.IsNullOrEmpty(Description)) throw new ArgumentException("Invalid description");
            if (Difficult <= 0) throw new ArgumentException("Invalid diffcult");
            if (Price < 0) throw new ArgumentException("Invalid price");
            if (AuthorId == 0) throw new ArgumentException("Invalid AuthorId");
        }
    }
}

public enum TourStatus
{
    Draft
}
