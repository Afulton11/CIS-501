using System.Collections.Generic;

namespace VerificationTool.Entities
{
    public class Facility
    {
        public string Building { get; set; }
        public string Room { get; set; }

        public IList<Section> Sections { get; set; }
    }
}
