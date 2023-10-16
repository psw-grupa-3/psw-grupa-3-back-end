using Explorer.BuildingBlocks.Core.Domain;

namespace Explorer.Blog.Core.Domain
{
    public enum BlogStatus { DRAFT = 1, PUBLISHED, CLOSED };
    public class Blog : Entity
    {
        public string Title { get; init; }
        public string Description { get; init; }
        public DateTime CreationDate { get; init; } = DateTime.Now;
        public BlogStatus Status { get; init; } = BlogStatus.DRAFT;

        public Blog(string title, string description, DateTime creationDate,
            BlogStatus status)
        {
            if (string.IsNullOrEmpty(title)) throw new ArgumentException("Invalid or empty title.");
            if (string.IsNullOrEmpty(description)) throw new ArgumentException("Invalid or empty description.");
            Title = title;
            Description = description;
            CreationDate = creationDate;
            Status = status;
        }
    }
}