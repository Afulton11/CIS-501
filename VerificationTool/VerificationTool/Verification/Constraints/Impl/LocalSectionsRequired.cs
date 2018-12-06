using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VerificationTool.Entities;

namespace VerificationTool.Verification.Constraints.Impl
{
    public class LocalSectionsRequired : ScheduleConstraint
    {
        protected override string getErrorMessage()
        {
            throw new NotImplementedException();
        }

        protected override bool Test(Semester local, Semester remote)
        {
            throw new NotImplementedException();
        }
    }
}
