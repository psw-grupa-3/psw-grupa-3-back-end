using Explorer.BuildingBlocks.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Explorer.Tours.Core.Domain
{
    public class Problem : Entity
    {
        public string Category { get; init; }
        public bool Priority { get; init; }
        public string Description { get; init; }
        public DateTime Time { get; init; } = DateTime.Now;
        public int TourId { get; init; }
        public Problem() { }

        public Problem(string category, bool priority, string description, DateTime time, int tourId)
        {
            if (string.IsNullOrWhiteSpace(category)) throw new ArgumentException("Invalid category.");
            Category = category;
            Priority = priority;
            if (string.IsNullOrWhiteSpace(description)) throw new ArgumentException("Invalid description.");
            Description = description;
            Time = time;
            TourId = tourId;
        }
    }
}
