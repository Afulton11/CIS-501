using System.Collections.Generic;
using VerificationTool.Entities;

namespace VerificationTool.Verification.Comparers
{
    public class SimpleFacilityComparer : EqualityComparer<Facility>
    {
        private static SimpleFacilityComparer instance;
        public static SimpleFacilityComparer Instance
        {
            get => instance ?? (instance = new SimpleFacilityComparer());
        }
        private SimpleFacilityComparer() { }


        public override bool Equals(Facility x, Facility y) =>
            x.Room == y.Room
            && x.Building == y.Building;

        public override int GetHashCode(Facility obj) => (obj.Room?.GetHashCode() ?? 0) + obj.Building.GetHashCode();
    }
}
