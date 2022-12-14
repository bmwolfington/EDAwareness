namespace EDAwareness.Core.Journal
{
    public class JournalEvent
    {
        public long Id { get; set; }
        public int? CommanderId { get; set; }

        public DateTime TimestampUtc { get; set; }
        public JournalEventType EventType { get; set; }
    }
}
