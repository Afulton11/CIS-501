using System.Collections.Generic;

namespace Project1.Entities
{
    public class Schedule
    {
        public string SemesterName { get; set; }
        public IEnumerable<SISClass> Classes { get; set; }
    }
}
