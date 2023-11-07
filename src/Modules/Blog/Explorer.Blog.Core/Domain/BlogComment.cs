using Explorer.BuildingBlocks.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Explorer.Blog.Core.Domain
{
    public class BlogComment : ValueObject
    {
        public int UserId { get; init; }
        public int BlogId { get; init; }
        public string Comment { get; private set; }
        public DateTime TimeCreated { get; init; }
        public DateTime TimeUpdated { get; private set; }

        [JsonConstructor]
        public BlogComment(int userId, int blogId, string comment, DateTime timeCreated, DateTime timeUpdated)
        {

            if (userId == 0) throw new ArgumentException("Invalid UserId");
            UserId = userId;
            if (blogId == 0) throw new ArgumentException("Invalid BlogId");
            BlogId = blogId;
            if (string.IsNullOrWhiteSpace(comment)) throw new ArgumentException("Invalid Name.");
            Comment = comment;
            TimeCreated = timeCreated;
            TimeUpdated = timeUpdated;
        }
        public void UpdateComment(BlogComment newComment)
        {
            Comment = newComment.Comment;
            TimeUpdated = newComment.TimeUpdated;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return UserId;
            yield return BlogId;
            yield return Comment;
            yield return TimeCreated;
            yield return TimeUpdated;
        }
    }
}
