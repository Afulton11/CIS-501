using System.Collections.Generic;
using VerificationTool.Entities;

namespace VerificationTool.Verification.Comparers
{
    public class SimpleCourseComparer : EqualityComparer<Course>
    {
        private static SimpleCourseComparer instance;

        public static SimpleCourseComparer Instance
        {
            get => instance ?? (instance = new SimpleCourseComparer());
        }

        private SimpleCourseComparer() { }


        public override bool Equals(Course x, Course y) =>
            x.Subject == y.Subject
            && x.CatalogNbr == y.CatalogNbr;

        public override int GetHashCode(Course obj) => obj.Subject.GetHashCode() + obj.CatalogNbr.GetHashCode();
    }
}
