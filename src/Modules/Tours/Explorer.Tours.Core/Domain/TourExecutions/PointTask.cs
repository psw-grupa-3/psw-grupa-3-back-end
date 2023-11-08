using Explorer.Tours.Core.Domain.Tours;

namespace Explorer.Tours.Core.Domain.TourExecutions
{
    public class PointTask: Task
    {
        public Point Point { get; init; }
        public PointTask(Point point, TaskType taskType) : base(taskType)
        {
            Point = point;
        }
    }
}
