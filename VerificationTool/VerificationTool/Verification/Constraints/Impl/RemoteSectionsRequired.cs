using System.Collections.Generic;
using System.Linq;
using VerificationTool.Entities;
using VerificationTool.Verification.Comparers;
using VerificationTool.Verification.Constraints.Impl.Errors;

namespace VerificationTool.Verification.Constraints.Impl
{
    public class RemoteSectionsRequired : ScheduleConstraint
    {
        private SectionErrorMessage errorMessage = new SectionErrorMessage("<<", "not found in current semester!");
        private IDictionary<Course, IEnumerable<string>> localCourseMap = new Dictionary<Course, IEnumerable<string>>(SimpleCourseComparer.Instance);
        private IDictionary<Course, IEnumerable<string>> remoteCourseMap = new Dictionary<Course, IEnumerable<string>>(SimpleCourseComparer.Instance);

        protected override string getErrorMessage() => errorMessage.ToString();

        protected override bool Test(Schedule local, Schedule remote)
        {
            errorMessage.Clear();
            PopulateMaps(local.Courses, remote.Courses);

            foreach (var remoteEntry in remoteCourseMap)
                foreach (var remoteSection in remoteEntry.Value)
                    if (!DoesSectionExistLocally(remoteEntry.Key, remoteSection))
                        errorMessage.AddSection(remoteEntry.Key, remoteSection);

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

        private bool DoesSectionExistLocally(Course remoteCourse, string remoteSectionNumber) =>
            localCourseMap.ContainsKey(remoteCourse)
            && localCourseMap[remoteCourse].Any(localSectionNumber => localSectionNumber == remoteSectionNumber);
       
    }
}
