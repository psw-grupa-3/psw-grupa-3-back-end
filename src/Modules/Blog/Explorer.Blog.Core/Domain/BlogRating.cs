using System.Text.Json.Serialization;
using Explorer.BuildingBlocks.Core.Domain;

namespace Explorer.Blog.Core.Domain
{
    public enum Vote {PLUS = 1, MINUS}
    public class BlogRating: ValueObject
    {

        public long UserId { get; init; }
        public DateTime VotingDate { get; private set; }
        public Vote Mark { get; private set; }


        [JsonConstructor]
        public BlogRating(long userId, DateTime votingDate, Vote mark)
        {
            UserId = userId;
            VotingDate = votingDate;
            Mark = mark;
        }

        public void UpdateRating(BlogRating newRating)
        {
            Mark = newRating.Mark;
            VotingDate = newRating.VotingDate;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return UserId;
            yield return VotingDate;
            yield return Mark;
        }
    }
}
