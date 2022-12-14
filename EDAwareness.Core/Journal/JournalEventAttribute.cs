namespace EDAwareness.Core.Journal
{
    /// <summary>
    /// When applied to a subclass of <see cref="JournalEvent"/>, will automatically deserialize
    /// an event of that type when parsing journal files.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class JournalEventAttribute : Attribute
    {
        public JournalEventType EventType { get; set; }

        public JournalEventAttribute(JournalEventType eventType) => EventType = eventType;
    }
}
