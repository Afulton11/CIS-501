using System.Collections.Generic;
using System.Linq;
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

        public override bool Equals(Instructor x, Instructor y) => 
            x.Name == y.Name
            && x.Sections.Any(xSection => y.Sections.Any(ySection => SectionComparer.Instance.Equals(xSection, ySection)));

        public override int GetHashCode(Instructor obj) => obj.Name.GetHashCode();
    }
}
