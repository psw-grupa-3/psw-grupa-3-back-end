using Explorer.BuildingBlocks.Core.Domain;

namespace Explorer.Payments.Core.Domain.Session
{
    public class ShoppingSession : Entity
    {
        public long UserId { get; private set; }
        public List<Event> Events { get; private set; }
        public bool IsActive { get; private set; }

        public ShoppingSession(long userId, List<Event> events, bool isActive)
        {
            UserId = userId;
            Events = events;
            IsActive = isActive;
            Validate();

        }

        private void Validate()
        {
            if (UserId == 0) throw new Exception("User doesn't exist");
        }

        internal void CloseSession(Event closeEvent)
        {
            Events.Add(closeEvent);
            IsActive = false;
        }

        internal void AddEvent(Event @event)
        {
            Events.Add(@event);
        }
    }
}
