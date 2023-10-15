using Explorer.BuildingBlocks.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Blog.Core.Domain
{
    public enum BlogStatus { DRAFT = 1, PUBLISHED, CLOSED };
    public class Blog: Entity
    {
        public String Title { get; init; }
        public String Description { get; init; }
        public DateTime CreationDate { get; init; } = DateTime.Now;
        public BlogStatus Status { get; init; } = BlogStatus.DRAFT;
        public List<string>? Images { get; init; }

        public Blog(string title, string description, DateTime creationDate,
            BlogStatus status, List<string>? images)
        {
            if(string.IsNullOrEmpty(title)) throw new ArgumentException("Invalid or empty title.");
            if(string.IsNullOrEmpty(description)) throw new ArgumentException("Invalid or empty description.");
            Title = title; 
            Description = description;
            CreationDate = creationDate;
            Status = status;
            Images = images;
        }
    }
}
