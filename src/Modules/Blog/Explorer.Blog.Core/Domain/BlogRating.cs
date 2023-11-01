using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Explorer.BuildingBlocks.Core.Domain;

namespace Explorer.Blog.Core.Domain
{
    public enum Vote {PLUS = 1, MINUS}
    public class BlogRating: ValueObject
    {

        public long BlogId { get; init; }
        public long UserId { get; init; }
        public DateTime VotingDate { get; init; }
        public Vote Mark { get; init; }


        [JsonConstructor]
        public BlogRating(long blogId, long userId, DateTime votingDate, Vote mark)
        {
            BlogId = blogId;
            UserId = userId;
            VotingDate = votingDate;
            Mark = mark;
        }


        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return BlogId;
            yield return UserId;
            yield return VotingDate;
            yield return Mark;
        }
    }
}
