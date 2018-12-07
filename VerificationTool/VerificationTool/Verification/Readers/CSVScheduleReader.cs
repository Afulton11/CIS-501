using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using VerificationTool.Entities;
using VerificationTool.utilities;
using VerificationTool.Verification.Comparers;
using VerificationTool.Verification.Readers.Exceptions;

namespace VerificationTool.Verification.Readers
{
    public class CSVScheduleReader : IScheduleReader
    {
        private const string FILETYPE = "csv";
        private const int SEMESTER_ENTRY_COUNT = 2;
        private const int SECTION_ENTRY_COUNT = 23;
        private static readonly char[] CSV_SEPARATORS = new char[] { ',' };
        private static readonly char[] NAME_YEAR_SEPARATORS = new char[] { ' ', ',' };

        private string filename;
        private IDictionary<Course, IList<Section>> courseMap = new Dictionary<Course, IList<Section>>(CourseComparer.Instance);
        private IDictionary<Instructor, IList<Section>> instructorMap = new Dictionary<Instructor, IList<Section>>(InstructorComparer.Instance);
        private IDictionary<Facility, IList<Section>> facilityMap = new Dictionary<Facility, IList<Section>>(FacilityComparer.Instance);


        public Schedule Read(string filepath)
        {
            courseMap.Clear();
            instructorMap.Clear();
            facilityMap.Clear();

            filename = Path.GetFileName(filepath);

            using (TextReader reader = new StreamReader(filepath))
            {
                var lines = ReadLines(reader);
                return ReadSchedule(lines);
            }

            // if anything abnormal occurs, we will always throw an invalid file format exception.
            throw new InvalidFileFormatException(filename, FILETYPE);
        }

        private IEnumerable<string> ReadLines(TextReader reader)
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                yield return line;
            }
        }

        private Schedule ReadSchedule(IEnumerable<string> lines)
        {
            Semester semester = ReadSemester(lines.First());

            // skip column names
            lines = lines.Skip(1);
            
            semester.Schedule = ReadSections(lines);

            IEnumerable<Course> courses = FlattenCourseMap();
            IEnumerable<Instructor> instructors = FlattenInstructorMap();
            IEnumerable<Facility> facilities = FlattenFacilityMap();

            return new Schedule()
            {
                Semester = semester,
                Courses = courses,
                Instructors = instructors,
                Facilities = facilities,
            };
        }

        private IEnumerable<Facility> FlattenFacilityMap()
        {
            foreach (var entry in facilityMap)
            {
                var facility = entry.Key;
                facility.Sections = entry.Value;

                yield return facility;
            }
        }

        private IEnumerable<Instructor> FlattenInstructorMap()
        {
            foreach (var entry in instructorMap)
            {
                var instructor = entry.Key;
                instructor.Sections = entry.Value;

                yield return instructor;
            }
        }

        private IEnumerable<Course> FlattenCourseMap()
        {
            foreach (var entry in courseMap)
            {
                var course = entry.Key;
                course.Sections = entry.Value;

                yield return course;
            }
        }

        private Semester ReadSemester(string line)
        {
            string[] values = line.Split(NAME_YEAR_SEPARATORS, StringSplitOptions.RemoveEmptyEntries);

            if (values.Length < SEMESTER_ENTRY_COUNT)
                throw new InvalidFileFormatException(filename, FILETYPE);

            return new Semester()
            {
                Name = values[0],
                Year = values[1],
            };
        }

        private IList<Section> ReadSections(IEnumerable<string> lines)
        {
            var sections = new List<Section>();
            foreach (var sectionLine in lines)
                sections.Add(ReadSection(sectionLine));

            return sections;
        }

        private Section ReadSection(string line)
        {
            string[] entries = line.Split(CSV_SEPARATORS);

            if (entries.Length < SECTION_ENTRY_COUNT)
                throw new InvalidFileFormatException(filename, FILETYPE);

            var courseKey = ReadCourse(entries);
            var instructorKey = ReadInstructor(entries);
            var facilityKey = ReadFacility(entries);
            var section = ReadSection(entries);

            AddCourseSection(courseKey, section, entries[2]);
            AddInstructorSection(instructorKey, section);
            AddFacilitySection(facilityKey, section);

            return section;
        }

        private Course ReadCourse(string[] entries) =>
            new Course()
            {
                Subject = entries[0],
                CatalogNbr = entries[1],
            };

        private Instructor ReadInstructor(string[] entries) =>
            new Instructor()
            {
                Name = entries[3],
            };

        private Facility ReadFacility(string[] entries)
        {
            var facilityId = entries[10];
            string building, room = null;

            var roomIndex = StringUtility.FirstIndexWhere(facilityId, c => char.IsDigit(c));
            if (roomIndex != -1)
            {
                building = facilityId.Substring(0, roomIndex);
                room = facilityId.Substring(roomIndex + 1);
            }
            else
                building = facilityId;

            return new Facility()
            {
                Building = building,
                Room = room,
            };
        }

        private Section ReadSection(string[] entries) =>
            new Section()
            {
                SectionNumber = entries[3],
                Consent = entries[5],
                EnrlCap = entries[6],
                TopicDescr = entries[7],
                MeetingStartDt = entries[8],
                MeetingEndDt = entries[9],
                MeetingStartTime = entries[11],
                MeetingEndTime = entries[12],
                days = ReadDays(entries),
                UnitsMin = entries[20],
                UnitsMax = entries[21],
                ClassAssn = entries[22],
            };

        private bool[] ReadDays(string[] entries)
        {
            const int START_ENTRY = 13;
            bool[] days = new bool[7];

            for (int i = 0; i < days.Length; i++)
                days[i] = ReadBool(entries[i + START_ENTRY]);

            return days;
        }

        private bool ReadBool(string value) => value.Equals("Y", StringComparison.OrdinalIgnoreCase);

        private void AddCourseSection(Course key, Section section, string classDescr)
        {
            if (courseMap.ContainsKey(key))
                courseMap[key].Add(section);
            else
            {
                key.ClassDescr = classDescr;
                courseMap.Add(key, new List<Section>() { section });
            }
        }

        private void AddInstructorSection(Instructor key, Section section)
        {
            if (instructorMap.ContainsKey(key))
                instructorMap[key].Add(section);
            else
                instructorMap.Add(key, new List<Section>() { section });
        }

        private void AddFacilitySection(Facility key, Section section)
        {
            if (facilityMap.ContainsKey(key))
                facilityMap[key].Add(section);
            else
                facilityMap.Add(key, new List<Section>() { section });
        }

    }

}
