using System.Text.Json.Serialization;
using Explorer.BuildingBlocks.Core.Domain;

namespace Explorer.Tours.Core.Domain.TourExecutions
{
    public enum TaskType {POINT = 1}
    public class Task: ValueObject
    {
        public bool Done { get; set; }
        public DateTime DoneOn { get; set; }
        public TaskType Type { get; set; }

        [JsonConstructor]
        public Task(TaskType type)
        {
            Done = false;
            DoneOn = DateTime.MinValue;
            Type = type;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Done;
            yield return DoneOn;
            yield return Type;
        }
    }
}
