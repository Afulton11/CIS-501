using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VerificationTool.Entities;
using VerificationTool.Verification.Comparers;
using VerificationTool.Verification.Constraints.Impl.Errors;

namespace VerificationTool.Verification.Constraints.Impl
{
    public class LocalSectionsRequired : ScheduleConstraint
    {
        private SectionErrorMessage errorMessage = new SectionErrorMessage(">>", "is new in the current semester!");
        private ISet<Course> localCourseSet = new HashSet<Course>(SimpleCourseComparer.Instance);
        private ISet<Course> remoteCourseSet = new HashSet<Course>(SimpleCourseComparer.Instance);

        protected override string getErrorMessage() => errorMessage.ToString();

        protected override bool Test(Schedule local, Schedule remote)
        {
            errorMessage.Clear();
            PopulateSets(local.Courses, remote.Courses);

            foreach (var localCourse in localCourseSet)
                foreach (var localSection in localCourse.Sections)
                    if (!DoesSectionExistRemotely(localCourse, localSection))
                        errorMessage.AddSection(localCourse, localSection.SectionNumber);

            return !errorMessage.HasErrors();
        }

        private void PopulateSets(IEnumerable<Course> localCourses, IEnumerable<Course> remoteCourses)
        {
            PopulateSet(localCourses, localCourseSet);
            PopulateSet(remoteCourses, remoteCourseSet);
        }

        private void PopulateSet(IEnumerable<Course> courses, ISet<Course> map)
        {
            map.Clear();
            foreach (var course in courses)
                map.Add(course);
        }

        private bool DoesSectionExistRemotely(Course localCourse, Section localSection) =>
            remoteCourseSet.Contains(localCourse)
            && remoteCourseSet.Any(course => 
                course.Sections.Any(remoteSection => remoteSection.SectionNumber == localSection.SectionNumber));
    }
}
