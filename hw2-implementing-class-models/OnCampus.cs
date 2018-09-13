namespace Homework
{
    public class OnCampus
    {
        private Semester sem;
        private Course cour;
        private Faculty teach;
        private string num;
        private int c;

        public OnCampus(Semester semester, Course course, Faculty teacher, string number, int cap)
        {
            sem = semester;
            cour = course;
            teach = teacher;
            num = number;
            c = cap;
        }

        public override string ToString()
        {
            return "Semester: " + sem.ToString() +
                    "\nCourse: " + cour.ToString() +
                    "\nFaculty: " + teach.ToString() +
                    "\nNumber: " + num +
                    "\nCap: " + c;
        }
    }
}