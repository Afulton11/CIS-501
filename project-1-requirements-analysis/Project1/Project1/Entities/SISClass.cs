using System;

namespace Project1.Entities
{
    public class SISClass
    {
        public string Subject { get; set; }
        public int CatalogNumber { get; set; }
        public string Description { get; set; }
        public string Section { get; set; }
        public string Instructor { get; set; }
        public string Consent { get; set; }
        public int EnrollmentCap { get; set; }
        public string TopicDescription { get; set; }
        public DateTime MeetingStartDate { get; set; }
        public DateTime MeetingEndDate { get; set; }
        public string FacilityId { get; set; }
        public TimeSpan MeetingTimeStart { get; set; }
        public TimeSpan MeetingTimeEnd { get; set; }
        public MeetingDays MeetingDays { get; set; } = new MeetingDays();
        public int CreditsMin { get; set; }
        public int CreditsMax { get; set; }
        public string MeetingType { get; set; }
    }
}
