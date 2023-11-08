using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Explorer.BuildingBlocks.Core.Domain;
using Explorer.Tours.Core.Domain.Tours;
using Explorer.Tours.Core.Domain.Utilities;
using static Explorer.Tours.API.Enums.TourEnums;

namespace Explorer.Tours.Core.Domain.TourExecutions
{
    public class TourExecution: Entity
    {
        private const int PointProximity = 100;
        public long UserId { get; init; }
        public TourExecutionStatus Status { get; set; }
        public Position Position { get; set; }
        public List<Task> Tasks { get; private set; }

        [JsonConstructor]
        public TourExecution(long id, long userId, List<Task> tasks, Position position)
        {
            Validate(userId);
            Id = id;
            UserId = userId;
            Tasks = tasks;
            Position = position;
            Status = TourExecutionStatus.Active;
        }

        public TourExecution(long userId, List<Point> points, Position position)
        {
            Validate(userId);
            UserId = userId;
            Position = position;
            Status = TourExecutionStatus.Active;
            PrepareTasks(points);
        }
        public void UpdatePosition(Position currentPosition)
        {
            if (Status != TourExecutionStatus.Active) return;
            if (!Position.IsChanged(currentPosition)) return;
            Position = currentPosition;
            var pointTasks = Tasks.FindAll(x => x.Type == TaskType.Point).OfType<PointTask>().ToList();
            var currentPoint = pointTasks.FirstOrDefault(x => !x.Done) ?? throw new Exception("Exception! All Tour Points passed!");
            var inProximity = DistanceCalculator.CalculateDistance(currentPoint, currentPosition) * 1000 <= PointProximity;
            if (inProximity)
            {
                currentPoint.Done = true;
                currentPoint.DoneOn = currentPosition.LastActivity;
            }
            Status = pointTasks.TrueForAll(x => x.Done) ? TourExecutionStatus.Completed : Status;
        }
        public void QuitTourExecution()
        {
            Status = TourExecutionStatus.Abandoned;
        }
        private void PrepareTasks(IReadOnlyCollection<Point> points)
        {
            if (points.Count < 0) throw new ArgumentException("Exception! No points found!");
            Tasks.AddRange(
                points.Select(x => new PointTask(x, TaskType.Point)));
        }

        private static void Validate(long userId)
        {
            if (userId < 1) throw new ArgumentException("Exception! Invalid value of UserId!");
        }
    }
}
