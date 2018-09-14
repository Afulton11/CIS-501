using System.Collections.Generic;

namespace Homework
{
    public abstract class Section
    {
        protected Course _course;
        protected Faculty _faculty;
        protected Semester _semester;

        public Section(Semester s, Course c, Faculty t, string num, int cap)
        {
            _semester = s;
            _course = c;
            _faculty = t;
            Number = num;
            Cap = cap;
        } 

        public string Number { get; set; }

        public int Cap { get; set; }

    }
}