using System;
using System.Text;
using VerificationTool.Entities;

namespace VerificationTool.utilities
{
    public static class StringUtility
    {

        public static string AddLine(string s, string line) =>
            new StringBuilder(s).AppendLine(line).ToString();

        /// <summary>
        /// Returns the first index where the predicate returns true.
        /// </summary>
        /// <param name="s">the array of characters represented as a string to get the index from</param>
        /// <param name="predicate">a predicate to test each character against in the given string</param>
        /// <returns></returns>
        public static int FirstIndexWhere(string s, Predicate<char> predicate)
        {
            for(int i = 0; i < s.Length; i++)
            {
                if (predicate(s[i])) return i;
            }

            return -1;
        }

        public static string ScheduleToString(Schedule schedule)
        {
            var builder = new StringBuilder();

            builder.AppendLine($"{schedule.Semester.Name} {schedule.Semester.Year}");

            foreach (var course in schedule.Courses)
                foreach (var section in course.Sections)
                {
                    builder.AppendLine($"Section {course.Subject} {course.CatalogNbr} Section {section.SectionNumber}");
                }

            return builder.ToString();
        }


        public static StringBuilder BuildSectionStringPrefix(Course course, string sectionNumber)
        {
            var builder = new StringBuilder();
            builder.Append("Section ");
            builder.Append(course.Subject);
            builder.Append(' ');
            builder.Append(course.CatalogNbr);
            builder.Append(' ');
            builder.Append("Section ");
            builder.Append(sectionNumber);

            return builder;
        }

        
    }
}
