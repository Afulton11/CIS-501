using System.Collections.Generic;
using System.Linq;
using VerificationTool.Entities;

namespace VerificationTool.Verification.Comparers
{
    public class FacilityComparer : EqualityComparer<Facility>
    {
        private static FacilityComparer instance;
        public static FacilityComparer Instance
        {
            get => instance ?? (instance = new FacilityComparer());
        }
        private FacilityComparer() { }


        public override bool Equals(Facility x, Facility y) =>
            x.Room == y.Room
            && x.Building == y.Building
            && x.Sections.Any(xSection => y.Sections.Any(ySection => SectionComparer.Instance.Equals(xSection, ySection)));

        public override int GetHashCode(Facility obj) => (obj.Room?.GetHashCode() ?? 0) + obj.Building.GetHashCode();
    }
}
