using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Explorer.Payments.API.Enums.EventEnums;

namespace Explorer.Payments.API.Dtos
{
    public class EventDto
    {
        public EventType EventType { get; set; }
        public long? ItemId { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
