using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using VerificationTool.Entities;
using VerificationTool.Verification.Readers.Exceptions;

namespace VerificationTool.Verification.Readers
{
    public class CSVScheduleReader : IScheduleReader
    {
        private const string FILETYPE = "csv";
        private const int SEMESTER_ENTRY_COUNT = 2;
        private const int SECTION_ENTRY_COUNT = 23;
        private static readonly char[] CSV_SEPARATORS = new char[] { ',' };
        private static readonly char[] NAME_YEAR_SEPARATORS = (new char[] { ' ', ',' });

        private string filename;
        private IDictionary<Course, IList<Section>> courseMap = new Dictionary<Course, IList<Section>>(new CourseComparer());

        public Semester Read(string filepath)
        {
            courseMap.Clear();
            filename = Path.GetFileName(filepath);

            using (TextReader reader = new StreamReader(filepath))
            {
                var lines = ReadLines(reader);
                Semester semester = ReadSemester(lines.First());
                
            }

            throw new InvalidFileFormatException(filename, FILETYPE);
        }

        public IEnumerable<string> ReadLines(TextReader reader)
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                yield return line;
            }
        }

        public Semester ReadSemester(string line)
        {
            string[] values = line.Split(NAME_YEAR_SEPARATORS, StringSplitOptions.RemoveEmptyEntries);

            if (values.Length != SEMESTER_ENTRY_COUNT)
                throw new InvalidFileFormatException(filename, FILETYPE);

            return new Semester()
            {
                Name = values[0],
                Year = values[1],
            };
        }

        public List<Course> ReadCourses(IEnumerable<string> lines)
        {
            var sections = new List<Course>();
            foreach (var course in lines)
                sections.Add(ReadCourse(course));

            return sections;
        }

        public Course ReadCourse(string line)
        {
            string[] entries = line.Split(CSV_SEPARATORS);

            if (entries.Length != SECTION_ENTRY_COUNT)
                throw new InvalidFileFormatException(filename, FILETYPE);

            var courseKey = new Course()
            {
                Subject = entries[0],
                CatalogNbr = entries[1],
                ClassDescr = entries[2],
            };

            IList<Section> sections;

            if (courseMap.ContainsKey(courseKey))
                sections = courseMap[courseKey];
            else
            {
                courseMap.Add(courseKey, sections = new List<Section>());
            }

            return courseKey;
        }

        public bool ReadBool(string value) => value.Equals("Y", StringComparison.OrdinalIgnoreCase);

        public class CourseComparer : EqualityComparer<Course>
        {
            public override bool Equals(Course x, Course y) => x.Subject == y.Subject && x.CatalogNbr == y.CatalogNbr;

            public override int GetHashCode(Course obj) => obj.Subject.GetHashCode() + obj.CatalogNbr.GetHashCode();
        }

    }

}
