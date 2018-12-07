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
        private SectionErrorMessage errorMessage = new SectionErrorMessage("is new in the current semester!");
        private IDictionary<Course, IEnumerable<string>> localCourseMap = new Dictionary<Course, IEnumerable<string>>(CourseComparer.Instance);
        private IDictionary<Course, IEnumerable<string>> remoteCourseMap = new Dictionary<Course, IEnumerable<string>>(CourseComparer.Instance);

        protected override string getErrorMessage() => errorMessage.ToString();

        protected override bool Test(Schedule local, Schedule remote)
        {
            errorMessage.Clear();
            PopulateMaps(local.Courses, remote.Courses);

            foreach (var localEntry in localCourseMap)
                foreach (var localSection in localEntry.Value)
                    if (!DoesSectionExistRemotely(localEntry.Key, localSection))
                        errorMessage.AddSection(localEntry.Key, localSection);

            return !errorMessage.HasErrors();
        }

        private void PopulateMaps(IEnumerable<Course> localCourses, IEnumerable<Course> remoteCourses)
        {
            PopulateMap(localCourses, localCourseMap);
            PopulateMap(remoteCourses, remoteCourseMap);
        }

        private void PopulateMap(IEnumerable<Course> courses, IDictionary<Course, IEnumerable<string>> map)
        {
            map.Clear();
            foreach (var course in courses)
            {
                var sectionNumbers = course.Sections.Select(section => section.SectionNumber);
                map.Add(course, sectionNumbers);
            }
        }

        private bool DoesSectionExistRemotely(Course localCourse, string localSectionNumber) =>
            remoteCourseMap.ContainsKey(localCourse)
            && remoteCourseMap[localCourse].Any(remoteSectionNumber => remoteSectionNumber == localSectionNumber);
    }
}
