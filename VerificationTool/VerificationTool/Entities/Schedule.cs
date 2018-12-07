using System.Collections.Generic;

namespace VerificationTool.Entities
{
    public class Schedule
    {
        public Semester Semester { get; set; }
        public IEnumerable<Course> Courses { get; set; }
        public IEnumerable<Instructor> Instructors { get; set; }
        public IEnumerable<Facility> Facilities { get; set; }
    }
}
