namespace EDAwareness.Core.Journal.Events
{
    [JournalEvent(JournalEventType.Fileheader)]
    public class LoadGameEvent : JournalEvent
    {
        public string FID { get; set; }
        public string LoadGameCommander { get; set; }
        public string Ship { get; set; }
        public string Ship_Localised { get; set; }
        public string ShipFD { get; set; }
        public ulong ShipId { get; set; }
        public bool StartLanded { get; set; }
        public bool StartDead { get; set; }
        public string GameMode { get; set; }
        public string Group { get; set; }
        public long Credits { get; set; }
        public long Loan { get; set; }

        public string ShipName { get; set; }
        public string ShipIdent { get; set; }
        public double FuelLevel { get; set; }
        public double FuelCapacity { get; set; }

        public string Language { get; set; }

    }
}
