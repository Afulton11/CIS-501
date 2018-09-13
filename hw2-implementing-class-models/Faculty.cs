using System.Collections.Generic;

namespace Homework
{
    public class Faculty : IFaculty
    {
        private IEnumerable<Section> _sections;
        private string _name;

        public Faculty(string name)
        {
            _name = name;
        }

        public void AssignSection(Section assignedSection)
        {
            _sections.Add(assignedSection);
        }

        public string GetName()
        {
            return _name;
        }
    }
}