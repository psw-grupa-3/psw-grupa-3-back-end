using Explorer.BuildingBlocks.Core.Domain;
using Explorer.Tours.Core.Domain.Utilities;

namespace Explorer.Tours.Core.Domain.TourExecutions
{
    public enum TourExecutionStatus {ACTIVE = 1, COMPLETED, ABANDONED}
    public class TourExecution: Entity
    {
        private const int PointProximity = 100;
        public long UserId { get; init; }
        public TourExecutionStatus Status { get; set; }
        public Position Position { get; set; }
        public List<Task> Tasks { get; private set; }
        
        public TourExecution(long id, long userId, List<Task> tasks, Position position)
        {
            Id = id;
            UserId = userId;
            Tasks = tasks;
            Position = position;
            Status = TourExecutionStatus.ACTIVE;
        }

        public void updatePosition(Position currentPosition)
        {
            if (Status == TourExecutionStatus.ACTIVE)
            {
                Position = currentPosition;
                var pointTasks = Tasks.FindAll(x => x.Type == TaskType.POINT).OfType<PointTask>().ToList();
                var currentPoint = pointTasks.FirstOrDefault(x => !x.Done) ?? throw new Exception("Exception! All Tour Points passed!");
                var inProximity = DistanceCalculator.CalculateDistance(currentPoint, currentPosition) * 1000 <= PointProximity;
                if (inProximity)
                {
                    currentPoint.Done = true;
                    currentPoint.DoneOn = currentPosition.LastActivity;
                }
                Status = pointTasks.TrueForAll(x => x.Done) ? TourExecutionStatus.COMPLETED : Status;
            }
        }
        public void quitTourExecution()
        {
            Status = TourExecutionStatus.ABANDONED;
        }
    }
}
