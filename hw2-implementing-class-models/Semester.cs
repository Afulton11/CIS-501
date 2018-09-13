using System;

namespace Homework
{
    public class Semester
    {
        public Semester(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }

        public void IncludeSection(Section newSection)
        {

        }
    }
}
