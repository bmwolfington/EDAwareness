namespace EDAwareness.Core.Journal.Events
{
    [JournalEvent(JournalEventType.Docked)]
    public class DockedEvent : JournalEvent
    {
        public string? StationName { get; set; }
        public string? StationType { get; set; }
    }
}
