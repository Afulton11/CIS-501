using System.Collections.Generic;
using System.Linq;
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


        public override bool Equals(Course x, Course y) => 
            x.Subject == y.Subject
            && x.CatalogNbr == y.CatalogNbr
            && x.Sections.Any(xSection => y.Sections.Any(ySection => SectionComparer.Instance.Equals(xSection, ySection)));

        public override int GetHashCode(Course obj) => obj.Subject.GetHashCode() + obj.CatalogNbr.GetHashCode();
    }
}
