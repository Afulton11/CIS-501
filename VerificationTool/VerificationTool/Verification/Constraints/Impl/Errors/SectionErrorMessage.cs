using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VerificationTool.Entities;
using VerificationTool.utilities;
using VerificationTool.Verification.Comparers;

namespace VerificationTool.Verification.Constraints.Impl.Errors
{
    public class SectionErrorMessage
    {
        private readonly IDictionary<Course, IList<string>> errorMap = new Dictionary<Course, IList<string>>(CourseComparer.Instance);
        private readonly string messageSuffix;

        public SectionErrorMessage(string messageSuffix)
        {
            this.messageSuffix = messageSuffix;
        }

        public bool HasErrors() => errorMap.Count > 0;

        public void Clear() => errorMap.Clear();

        public void AddSection(Course key, string section)
        {
            if (errorMap.ContainsKey(key))
                errorMap[key].Add(section);
            else
                errorMap.Add(key, new List<string>() { section });
        }

        public override string ToString() => FormatErrors();

        private string FormatErrors()
        {
            var builder = new StringBuilder();
            foreach (var error in errorMap)
            {
                builder.Append(FormatError(error));
            }

            return builder.ToString();
        }

        private StringBuilder FormatError(KeyValuePair<Course, IList<string>> error)
        {
            var builder = new StringBuilder();
            foreach (var sectionNumber in error.Value)
            {
                builder.Append(FormatSection(error.Key, sectionNumber));
                builder.AppendLine();
            }

            return builder;
        }

        private StringBuilder FormatSection(Course course, string sectionNumber)
        {
            var builder = new StringBuilder();
            builder.Append(StringUtility.BuildSectionStringPrefix(course, sectionNumber));
            builder.Append(' ');
            builder.Append(messageSuffix);
            return builder;
        }
    }
}
