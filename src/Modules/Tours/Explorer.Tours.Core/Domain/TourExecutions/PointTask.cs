namespace Explorer.Tours.Core.Domain.TourExecutions
{
    public class PointTask: Task
    {
        public Points Point { get; init; }
        public PointTask(Points point, TaskType taskType) : base(taskType)
        {
            Point = point;
        }
    }
}
