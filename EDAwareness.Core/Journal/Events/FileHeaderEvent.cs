namespace EDAwareness.Core.Journal.Events
{
    [JournalEvent(JournalEventType.Fileheader)]
    public class FileHeaderEvent : JournalEvent
    {
        public string? GameVersion { get; set; }
        public string? Build { get; set; }
        public string? Language { get; set; }
        public int Part { get; set; }
        //public bool Odyssey { get; set; }
    }
}
