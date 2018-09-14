using System.Collections.Generic;

namespace Homework
{
    public class Faculty : IFaculty
    {
        private ICollection<Section> _sections;
        private string _name;

        public Faculty(string name)
        {
            _name = name;
            _sections = new List<Section>();
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