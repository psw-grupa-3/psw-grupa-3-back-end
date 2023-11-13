using Explorer.BuildingBlocks.Core.Domain;
using Explorer.Stakeholders.Core.Domain;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Explorer.Tours.Core.Domain.Tours
{
    public class Problem : Entity
    {
        [JsonPropertyName("category")]
        public string Category { get; init; }
        [JsonPropertyName("priority")]
        public bool Priority { get; init; }
        [JsonPropertyName("description")]
        public string Description { get; init; }
        [JsonPropertyName("time")]
        public DateTime Time { get; init; } = DateTime.Now;
        [JsonPropertyName("tourId")]
        public long TourId { get; init; }
        [JsonPropertyName("touristId")]
        public int TouristId { get; init; }
        [JsonPropertyName("authorsSolution")]
        public string AuthorsSolution { get; private set; }
        [JsonPropertyName("isSolved")]
        public bool IsSolved { get; private set; }
        [JsonPropertyName("unsolvedProblemComment")]
        public string UnsolvedProblemComment { get; private set; }
        [JsonPropertyName("deadline")]
        public DateTime Deadline { get; private set; }
        public Problem()
        {
        }

        [JsonConstructor]
        public Problem(long id, string category, bool priority, string description, DateTime time, long tourId, int touristId, string authorsSolution, bool isSolved, string unsolvedProblemComment, DateTime deadline)
        {
            Id = id;
            if (string.IsNullOrWhiteSpace(category)) throw new ArgumentException("Invalid category.");
            Category = category;
            Priority = priority;
            if (string.IsNullOrWhiteSpace(description)) throw new ArgumentException("Invalid description.");
            Description = description;
            Time = time;
            TourId = tourId;
            TouristId = touristId;
            AuthorsSolution = authorsSolution;
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

        public void RespondToProblem(string response)
        {
            AuthorsSolution = response;
        }

        public void LeaveUnsolvedComment(string comment)
        {
            IsSolved = false;
            UnsolvedProblemComment = comment;
        }

        public void SolveProblem()
        {
            IsSolved = true;
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
}
public static List<Problem> GetUnresolvedProblemsWithDeadline(List<Problem> problems)
{


return problems
.Where(problem => !problem.IsSolved && problem.Deadline < problem.Time)
.ToList();
}*/
    }
}