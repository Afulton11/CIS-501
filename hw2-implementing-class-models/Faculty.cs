namespace Homework
{
    public class Faculty : IFaculty
    {
        private IEnumerable<Section> _sections;
        public string Name { get; }
    }
}