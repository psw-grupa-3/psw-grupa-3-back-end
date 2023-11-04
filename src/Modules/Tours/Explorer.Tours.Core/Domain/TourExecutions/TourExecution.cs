using Explorer.BuildingBlocks.Core.Domain;
using Explorer.Tours.Core.Domain.Utilities;

namespace Explorer.Tours.Core.Domain.TourExecutions
{
    public enum TourExecutionStatus {ACTIVE = 1, COMPLETED, ABANDONED}
    public class TourExecution: Entity
    {
        public long UserId { get; init; }
        public TourExecutionStatus Status { get; set; }
        public Position Position { get; set; }
        public List<Task> Tasks { get; init; }
        
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
            Position = currentPosition;

            List<PointTask> pointTasks = Tasks.FindAll(x => x.Type == TaskType.POINT)
                .OfType<PointTask>().ToList();
            PointTask currentPoint = pointTasks.FirstOrDefault(x => !x.Done) ?? throw new Exception("Exception! All Tour Points passed!");

            currentPoint.Done = DistanceCalculator.CalculateDistance(currentPoint, currentPosition) * 1000 <= 100;
            Status = pointTasks.TrueForAll(x => x.Done) ? TourExecutionStatus.COMPLETED : Status;
        }

        public void quitTourExecution()
        {
            Status = TourExecutionStatus.ABANDONED;
        }
    }
}
