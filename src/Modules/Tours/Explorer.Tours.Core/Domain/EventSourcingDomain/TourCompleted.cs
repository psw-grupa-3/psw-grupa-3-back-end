using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Explorer.BuildingBlocks.Core.Domain;
using Explorer.Tours.Core.Domain.TourExecutions;

namespace Explorer.Tours.Core.Domain.EventSourcingDomain
{
    public class TourCompleted : DomainEvent
    {
        public TourCompleted(int aggregateId, Position position, DateTime time) : base(aggregateId)
        {
            Time = time;
            Position = position;
        }

        public DateTime Time { get; private set; }

        public Position Position { get; private set; }
    }
}
