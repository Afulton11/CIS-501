using System.Collections.Generic;

namespace VerificationTool.Entities
{
    public class Semester
    {
        public string Name { get; set; }
        public string Year { get; set; }
        public IList<Section> Schedule { get; set; }
    }
}
