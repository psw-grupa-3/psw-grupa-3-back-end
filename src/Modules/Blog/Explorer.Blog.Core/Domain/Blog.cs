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
        public string[] Images { get; init; }
        public long UserId { get; init; }
        public List<BlogComment> BlogComments { get; init; }

        public Blog(string title, string description, DateTime creationDate,
            BlogStatus status, string[] images, long userId)
        {
            if (string.IsNullOrEmpty(title)) throw new ArgumentException("Invalid or empty title.");
            if (string.IsNullOrEmpty(description)) throw new ArgumentException("Invalid or empty description.");
            Title = title;
            Description = description;
            CreationDate = creationDate.ToUniversalTime();
            Status = status;
            Images = images;
            UserId = userId;
            BlogComments = new List<BlogComment>();
        }
        public void UpdateComments(BlogComment comment)
        {
            BlogComment oldComment = BlogComments.Find(x =>
                x.UserId == comment.UserId && x.TimeCreated == comment.TimeCreated);
            oldComment.UpdateComment(comment);
        }
    }
}