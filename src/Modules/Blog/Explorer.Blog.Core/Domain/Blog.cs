using System.Text.Json.Serialization;
using Explorer.BuildingBlocks.Core.Domain;

namespace Explorer.Blog.Core.Domain
{
    public enum BlogStatus { DRAFT = 1, PUBLISHED, CLOSED, ACTIVE, FAMOUS };
    public class Blog : Entity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; init; } = DateTime.Now;
        public BlogStatus Status { get; private set; } = BlogStatus.DRAFT;
        public string[] Images { get; set; }
        public long UserId { get; init; }
        public List<BlogRating>? Ratings { get; init; }
        public int NetVotes { get; private set; }

        [JsonConstructor]
        public Blog(long id, string title, string description, DateTime creationDate,
            BlogStatus status, string[] images, long userId)
        {
            Validate(id, title, description);
            Id = id;
            Title = title;
            Description = description;
            CreationDate = creationDate.ToUniversalTime();
            Status = status;
            Images = images;
            UserId = userId;
            NetVotes = 0;
        }

        public void PublishBlog()
        {
            if (Status != BlogStatus.DRAFT)
                return;
            Status = BlogStatus.PUBLISHED;
        }   
        public void Rate(BlogRating rating)
        {
            BlogRating oldRating = Ratings.Find(x => x.UserId == rating.UserId);
            UpdateRatings(rating, oldRating);
            CalculateNetVotes();
            UpdateBlogStatus();
        }
        private void UpdateRatings(BlogRating rating, BlogRating? oldRating)
        {
            if (oldRating == null)
            {
                Ratings.Add(rating);
            }
            else if (oldRating.Mark == rating.Mark)
            {
                Ratings.Remove(oldRating);
            }
            else if (oldRating.Mark != rating.Mark)
            {
                oldRating.UpdateRating(rating);
            }
        }

        private void CalculateNetVotes()
        {
            var positiveRatings = Ratings.Count(x => x.Mark == Vote.PLUS);
            var negativeRatings = Ratings.Count(x => x.Mark == Vote.MINUS);
            NetVotes = positiveRatings - negativeRatings;
        }
        private void UpdateBlogStatus()
        {
            switch (NetVotes)
            {
                case -10:
                    Status = BlogStatus.CLOSED; break;
                case var n when n > 100:
                    Status = BlogStatus.ACTIVE; break;
                case var n when n > 500:
                    Status = BlogStatus.FAMOUS; break;
            }
        }
        private static void Validate(long id,string title, string description)
        {
            if(id < 1) throw new ArgumentException("Invalid value of Id.");
            if (string.IsNullOrEmpty(title)) throw new ArgumentException("Invalid or empty title.");
            if (string.IsNullOrEmpty(description)) throw new ArgumentException("Invalid or empty description.");
        }
    }
}