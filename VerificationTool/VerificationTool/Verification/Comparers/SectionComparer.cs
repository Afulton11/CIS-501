using System.Collections.Generic;
using System.Linq;
using VerificationTool.Entities;

namespace VerificationTool.Verification.Comparers
{
    public class SectionComparer : EqualityComparer<Section>
    {
        private static SectionComparer instance;
        public static SectionComparer Instance
        {
            get => instance ?? (instance = new SectionComparer());
        }
        private SectionComparer() { }

        public override bool Equals(Section x, Section y) =>
            x != null && y != null
            && x.SectionNumber == y.SectionNumber
            && x.Consent == y.Consent
            && x.EnrlCap == y.EnrlCap
            && x.TopicDescr == y.TopicDescr
            && x.MeetingStartDt == y.MeetingStartDt
            && x.MeetingEndDt == y.MeetingEndDt
            && x.MeetingStartTime == y.MeetingStartTime
            && x.MeetingEndTime == y.MeetingEndTime
            && Enumerable.SequenceEqual(x.days, y.days)
            && x.UnitsMin == y.UnitsMin
            && x.UnitsMax == y.UnitsMax
            && x.ClassAssn == y.ClassAssn;


        public override int GetHashCode(Section section)
        {
            int hashcode = 0;
            int hash(object obj) => hashcode += obj.GetHashCode();

            hash(section.SectionNumber);
            hash(section.Consent);
            hash(section.EnrlCap);
            hash(section.TopicDescr);
            hash(section.MeetingStartDt);
            hash(section.MeetingEndDt);
            hash(section.MeetingStartTime);
            hash(section.MeetingEndTime);
            hash(section.days);
            hash(section.UnitsMin);
            hash(section.UnitsMax);
            hash(section.ClassAssn);

            return hashcode;
        }

    }
}
