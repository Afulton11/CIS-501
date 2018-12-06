namespace VerificationTool.Entities
{
    public class Section
    {
        string SectionNumber { get; }
        string Consent { get; }
        string EnrlCap { get; }
        string TopicDescr { get; }
        string MeetingStartDt { get; }
        string MeetingEndDt { get; }
        string MeetingStartTime { get; }
        string MeetingEndTime { get; }
        bool[] days { get; } = new bool[7];
        string UnitsMin { get; }
        string UnitsMax { get; }
        string ClassAssn { get; }
    }
}
