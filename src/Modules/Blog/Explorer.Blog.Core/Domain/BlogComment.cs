using Explorer.BuildingBlocks.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Explorer.Blog.Core.Domain
{
    public class BlogComment : Entity
    {
        public int UserId { get; init; }
        public int BlogId { get; init; }
        public string Comment { get; init; }
        public DateTime TimeCreated { get; init; }
        public DateTime TimeUpdated { get; init; }

        public BlogComment(int userId, int blogId, string comment, DateTime timeCreated, DateTime timeUpdated)
        {

            if (userId == 0) throw new ArgumentException("Invalid UserId");
            UserId = userId;
            if (BlogId == 0) throw new ArgumentException("Invalid BlogId");
            BlogId = blogId;
            if (string.IsNullOrWhiteSpace(comment)) throw new ArgumentException("Invalid Name.");
            Comment = comment;
            TimeCreated = timeCreated;
            TimeUpdated = timeUpdated;
        }

        public BlogComment() { }
    }
}
