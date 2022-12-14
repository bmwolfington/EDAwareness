namespace EDAwareness.Core.Journal.Events
{
    [JournalEvent(JournalEventType.Continued)]
    public class ContinuedEvent : JournalEvent
    {
        public int Part { get; set; }
    }
}
