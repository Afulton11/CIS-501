namespace Homework
{
    /// <summary>
    /// A IFaculty interface can have 0 or more sections.
    /// </summary>
    public interface IFaculty
    {
        string GetName();

        void AssignSection(Section assignedSection);
    }
}