using Explorer.BuildingBlocks.Core.Domain;
using Newtonsoft.Json;

namespace Explorer.Encounters.Core.Domain
{
    public class Participant: ValueObject
    {
        public string Username { get; init; }
        public DateTime CompletionDate { get; private set; } = DateTime.MinValue;

        public Participant(){}

        public Participant(string username)
        {
            Username = username;
        }

        [JsonConstructor]
        public Participant(string username, DateTime completionDate)
        {
            Username = username;
            CompletionDate = completionDate;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Username;
            yield return CompletionDate;
        }
    }
}
