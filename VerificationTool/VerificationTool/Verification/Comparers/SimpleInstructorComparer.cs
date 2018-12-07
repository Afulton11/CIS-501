using System.Collections.Generic;
using VerificationTool.Entities;

namespace VerificationTool.Verification.Comparers
{
    public class SimpleInstructorComparer : EqualityComparer<Instructor>
    {
        private static SimpleInstructorComparer instance;
        public static SimpleInstructorComparer Instance
        {
            get => instance ?? (instance = new SimpleInstructorComparer());
        }
        private SimpleInstructorComparer() { }

        public override bool Equals(Instructor x, Instructor y) => x.Name == y.Name;

        public override int GetHashCode(Instructor obj) => obj.Name.GetHashCode();
    }
}
