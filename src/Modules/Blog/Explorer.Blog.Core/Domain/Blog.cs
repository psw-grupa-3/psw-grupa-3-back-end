﻿using Explorer.BuildingBlocks.Core.Domain;

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

        public Blog(string title, string description, DateTime creationDate,
            BlogStatus status, string[] images, long userId)
        {
            Validate(title, description);
            Title = title;
            Description = description;
            CreationDate = creationDate.ToUniversalTime();
            Status = status;
            Images = images;
            UserId = userId;
            NetVotes = 0;
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
        private static void Validate(string title, string description)
        {
            if (string.IsNullOrEmpty(title)) throw new ArgumentException("Invalid or empty title.");
            if (string.IsNullOrEmpty(description)) throw new ArgumentException("Invalid or empty description.");
        }
    }
}