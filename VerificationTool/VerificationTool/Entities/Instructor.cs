﻿using System.Collections.Generic;

namespace VerificationTool.Entities
{
    public class Instructor
    {
        public string Name { get; set;  }
        public IList<Section> Sections { get; set; }
    }
}
