using System.Collections.Generic;

namespace VerificationTool.Entities
{
    public class Course
    {
        public string Subject { get; set; }
        public string CatalogNbr { get; set; }
        public string ClassDescr { get; set; }
        public List<Section> Sections { get; set; }
    }
}
