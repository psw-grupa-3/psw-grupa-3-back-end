using Explorer.Encounters.Core.Domain.Participants;
using Explorer.Encounters.Core.Domain.Utilities;

namespace Explorer.Encounters.Core.Domain.SolvingStrategies
{
    public class SocialEncounter: Encounter
    {
        public int RequiredParticipants { get; private set; }
        public List<Participant> CurrentlyInRange { get; set; } = new List<Participant>();

        public SocialEncounter(){}

        public SocialEncounter(int requiredParticipants, List<Participant> currentlyInRange)
        {
            Validate(requiredParticipants, currentlyInRange);
            RequiredParticipants = requiredParticipants;
            CurrentlyInRange = currentlyInRange;
        }

        public List<Completer> Solve(string username, double longitude, double latitude)
        {
            var participantsLocation = new Location(longitude, latitude);
            var inProximity = DistanceCalculator.CalculateDistance(participantsLocation, Location) * 1000 <= Radius;
            if (!inProximity && CurrentlyInRange.Any(x => x.Username.Equals(username)))
                CurrentlyInRange.Remove(CurrentlyInRange.Find(x => x.Username.Equals(username)) ?? throw new NullReferenceException("Exception!"));
            if (inProximity && CurrentlyInRange.All(y => !y.Username.Equals(username))) CurrentlyInRange.Add(new Participant(username));
            var isSolved = RequiredParticipants == CurrentlyInRange.Count;
            if (isSolved)
            {
                List<Completer> completers = Participants.Select(participant => new Completer(participant.Username, DateTime.Now)).ToList();
                Completers.AddRange(completers);
                Participants.Clear();
                CurrentlyInRange.Clear();
                return completers;
            }
            return new List<Completer>();
        }

        private static void Validate(int requiredParticipants, List<Participant> currentlyInRange)
        {
            if (requiredParticipants < 1) throw new ArgumentException("Exception! Must be above 0");
            if (currentlyInRange == null) throw new ArgumentNullException("Exception! Must not be null!");
;       }
    }
}
