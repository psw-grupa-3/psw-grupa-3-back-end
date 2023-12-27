using Explorer.BuildingBlocks.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.Core.Domain.EventSourcingDomain
{
    public class TourStarted: DomainEvent
    {
        public TourStarted(int aggregateId, string username, DateTime time): base(aggregateId)
        {
            Time = time;
        }

        public DateTime Time { get; private set; }
    }

}
