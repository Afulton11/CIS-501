namespace VerificationTool.Entities
{
    public class Section
    {
        public string SectionNumber { get; set; }
        public string Consent { get; set; }
        public string EnrlCap { get; set; }
        public string TopicDescr { get; set; }
        public string MeetingStartDt { get; set; }
        public string MeetingEndDt { get; set; }
        public string MeetingStartTime { get; set; }
        public string MeetingEndTime { get; set; }
        public bool[] days { get; set; }
        public string UnitsMin { get; set; }
        public string UnitsMax { get; set; }
        public string ClassAssn { get; set; }
    }
}
