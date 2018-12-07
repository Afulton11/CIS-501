using System.Collections.Generic;
using VerificationTool.Entities;

namespace VerificationTool.Verification.Comparers
{
    public class CourseComparer : EqualityComparer<Course>
    {
        private static CourseComparer instance;
        
        public static CourseComparer Instance
        {
            get => instance ?? (instance= new CourseComparer());
        }

        private CourseComparer() { }


        public override bool Equals(Course x, Course y) => x.Subject == y.Subject && x.CatalogNbr == y.CatalogNbr;

        public override int GetHashCode(Course obj) => obj.Subject.GetHashCode() + obj.CatalogNbr.GetHashCode();
    }
}
