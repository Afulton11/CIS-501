namespace Homework
{
    public class Online
    {
        private Semester sem;
        private Course cour;
        private Faculty teach;
        private string num;
        private int c;

        public Online(Semester semester, Course course, Faculty teacher, string number, int cap)
        {
            sem = semester;
            cour = course;
            teach = teacher;
            num = number;
            c = cap;
        }

        public override string ToString()
            => $"{c} section {num} ({cour.Title}) is being taught by {teach.GetName()} in {sem.Name}";
    }
}