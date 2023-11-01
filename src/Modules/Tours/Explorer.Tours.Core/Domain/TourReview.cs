using Explorer.BuildingBlocks.Core.Domain;
using Explorer.Stakeholders.Core.Domain;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.Core.Domain
{
    public class TourReview : Entity
    {
        public int Rating { get; init; }
        public string Comment { get; init; }
        public int TouristId { get; init; }
        public string TouristUsername { get; init; }
        public DateTime TourDate { get; init; }
        public DateTime CreationDate { get; init; } = DateTime.Now;
        public List<string> Images { get; init; }
        public int TourId { get; init; }

        public TourReview(int rating, string comment, int touristId, string touristUsername, DateTime tourDate, DateTime creationDate, List<string> images, int tourId)
        {
            Rating = rating;
            Comment = comment;
            TouristId = touristId;
            TouristUsername = touristUsername;
            TourDate = tourDate;
            CreationDate = creationDate;
            Images = images ?? new List<string>();
            TourId = tourId;
            Validate();
        }
        private void Validate()
        {
            if (Rating < 1 || Rating > 5) throw new ArgumentException("Invalid rating");
            if (string.IsNullOrWhiteSpace(Comment)) throw new ArgumentException("Invalid or empty comment");
            if (TouristId == 0) throw new ArgumentException("Invalid TouristId");
            if (string.IsNullOrWhiteSpace(TouristUsername)) throw new ArgumentException("Invalid or empty tourist username");
            if (TourDate > DateTime.Now) throw new ArgumentException("Invalid tour date.");
            if (TourId == 0) throw new ArgumentException("Invalid TourId");
        }
    }
}
