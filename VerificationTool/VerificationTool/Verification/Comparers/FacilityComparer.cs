using System.Collections.Generic;
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


        public override bool Equals(Facility x, Facility y) => x.Room == y.Room && x.Building == y.Building;

        public override int GetHashCode(Facility obj) => (obj.Room?.GetHashCode() ?? 0) + obj.Building.GetHashCode();
    }
}
