using System;
using System.Collections.Generic;
using System.Linq;
using VerificationTool.Entities;
using VerificationTool.Verification.Comparers;
using VerificationTool.Verification.Constraints.Impl.Errors;

namespace VerificationTool.Verification.Constraints.Impl
{
    public class SectionsShouldNotDiffer : ScheduleConstraint
    {
        private SectionErrorMessage errorMessage = new SectionErrorMessage("has been changed in the current Semester!");
        private ISet<Course> localCourseSet = new HashSet<Course>(SimpleCourseComparer.Instance);
        private ISet<Course> remoteCourseSet = new HashSet<Course>(SimpleCourseComparer.Instance);
        private IDictionary<Section, Instructor> localInstructorMap = new Dictionary<Section, Instructor>(SectionComparer.Instance);
        private IDictionary<Section, Instructor> remoteInstructorMap = new Dictionary<Section, Instructor>(SectionComparer.Instance);
        private IDictionary<Section, Facility> localFacilityMap = new Dictionary<Section, Facility>(SectionComparer.Instance);
        private IDictionary<Section, Facility> remoteFacilityMap = new Dictionary<Section, Facility>(SectionComparer.Instance);

        protected override string getErrorMessage() => errorMessage.ToString();

        protected override bool Test(Schedule local, Schedule remote)
        {
            errorMessage.Clear();
            PopulateStructures(local, remote);

            foreach (var localCourse in localCourseSet)
                foreach (var localSection in localCourse.Sections)
                    if (DoesLocalSectionDifferFromRemoteSection(localCourse, localSection))
                        errorMessage.AddSection(localCourse, localSection.SectionNumber);

            return !errorMessage.HasErrors();
        }

        private void PopulateStructures(Schedule local, Schedule remote)
        {
            PopulateSet(localCourseSet, local.Courses);
            PopulateSet(remoteCourseSet, remote.Courses);
            PopulateInstructorMap(localInstructorMap, local.Instructors);
            PopulateInstructorMap(remoteInstructorMap, remote.Instructors);
            PopulateFacilityMap(localFacilityMap, local.Facilities);
        }

        private void PopulateSet(ISet<Course> set, IEnumerable<Course> courses)
        {
            set.Clear();
            foreach (var course in courses)
                set.Add(course);
        }

        private void PopulateInstructorMap(IDictionary<Section, Instructor> map, IEnumerable<Instructor> instructors)
        {
            map.Clear();
            foreach (var instructor in instructors)
                foreach (var section in instructor.Sections)
                    map.Add(section, instructor);

            foreach (var kvp in map)
            {
                Console.WriteLine($"{kvp.Key.MeetingStartTime}:{kvp.Key.SectionNumber}:{kvp.Value.Name}");
            }
        }

        private void PopulateFacilityMap(IDictionary<Section, Facility> map, IEnumerable<Facility> facilities)
        {
            map.Clear();
            foreach (var facility in facilities)
                foreach (var section in facility.Sections)
                    map.Add(section, facility);
        }

        private bool DoesLocalSectionDifferFromRemoteSection(Course localCourse, Section localSection)
        {
            if (remoteCourseSet.Contains(localCourse))
            {
                var remoteCourse = remoteCourseSet.Single(course => SimpleCourseComparer.Instance.Equals(course, localCourse));
                var remoteSection = remoteCourse.Sections.First(section => section.SectionNumber == localSection.SectionNumber);

                if (remoteCourse.CatalogNbr == "643" && remoteSection.SectionNumber == "A" || remoteSection.SectionNumber == "ZA")
                {
                    Console.WriteLine(
$@"
{remoteSection.MeetingStartTime}
{remoteSection.MeetingEndDt}
{remoteSection.TopicDescr}
");
                }

                return !SectionComparer.Instance.Equals(localSection, remoteSection)
                     || HasInstructorChanged(localSection, remoteSection)
                     || HasFacilityChanged(localSection, remoteSection);
            }

            return false;
        }

        private bool HasInstructorChanged(Section local, Section remote)
        {
            bool localInstructorExists = localInstructorMap.ContainsKey(local);
            bool remoteInstructorExists = remoteInstructorMap.ContainsKey(remote);

            if (localInstructorExists && remoteInstructorExists)
                return !SimpleInstructorComparer.Instance.Equals(localInstructorMap[local], remoteInstructorMap[remote]);
            else
                return localInstructorExists ^ remoteInstructorExists;
        }

        private bool HasFacilityChanged(Section local, Section remote)
        {
            //bool localFacilityExists = localFacilityMap.ContainsKey(local);
            //bool remoteFacilityExists = remoteFacilityMap.ContainsKey(remote);

            //if (localFacilityExists && remoteFacilityExists)
            //    return !SimpleFacilityComparer.Instance.Equals(localFacilityMap[local], remoteFacilityMap[remote]);
            //else
            //    return localFacilityExists ^ remoteFacilityExists;
            return false;
        }
    }
}
