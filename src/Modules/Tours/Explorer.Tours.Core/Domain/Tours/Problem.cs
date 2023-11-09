using Explorer.BuildingBlocks.Core.Domain;
using Explorer.Stakeholders.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Explorer.Tours.Core.Domain.Tours
{
    public class Problem : Entity
    {
        public string Category { get; init; }
        public bool Priority { get; init; }
        public string Description { get; init; }
        public DateTime Time { get; init; } = DateTime.Now;
        public int TourId { get; init; }
        public int TouristId { get; init; }
        public bool IsSolved { get; private set; }
        public string UnsolvedProblemComment { get; private set; }
        public DateTime Deadline { get; private set; }
        public Problem() { }

        [JsonConstructor]
        public Problem(string category, bool priority, string description, DateTime time, int tourId, int touristId, bool isSolved, string unsolvedProblemComment, DateTime deadline)
        {
            if (string.IsNullOrWhiteSpace(category)) throw new ArgumentException("Invalid category.");
            Category = category;
            Priority = priority;
            if (string.IsNullOrWhiteSpace(description)) throw new ArgumentException("Invalid description.");
            Description = description;
            Time = time;
            TourId = tourId;
            TouristId = touristId;
            IsSolved = isSolved;
            UnsolvedProblemComment = unsolvedProblemComment;
            Deadline = deadline;
        }
        public void UpdateProblem(Problem newProblem)
        {
            IsSolved = newProblem.IsSolved;
            if (!IsSolved)
            {
                UnsolvedProblemComment = newProblem.UnsolvedProblemComment;
            }
        }
        /*protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Category;
            yield return Priority;
            yield return Description;
            yield return Time;
            yield return TourId;
            yield return TouristId;
            yield return IsSolved;
            yield return UnsolvedProblemComment;
            yield return Deadline;
        }*/
    }
}
