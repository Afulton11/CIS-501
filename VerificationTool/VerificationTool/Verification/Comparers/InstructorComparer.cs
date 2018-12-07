using System.Collections.Generic;
using VerificationTool.Entities;

namespace VerificationTool.Verification.Comparers
{
    public class InstructorComparer : EqualityComparer<Instructor>
    {
        private static InstructorComparer instance;
        public static InstructorComparer Instance
        {
            get => instance ?? (instance = new InstructorComparer());
        }
        private InstructorComparer() { }

        public override bool Equals(Instructor x, Instructor y) => x.Name == y.Name;

        public override int GetHashCode(Instructor obj) => obj.Name.GetHashCode();
    }
}
