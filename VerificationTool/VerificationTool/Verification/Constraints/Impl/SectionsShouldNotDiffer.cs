using System;
using System.Collections.Generic;
using System.Linq;
using VerificationTool.Entities;

namespace VerificationTool.Verification.Constraints.Impl
{
    public class SectionsShouldNotDiffer : ScheduleConstraint
    {
        private ErrorMessage error;

        protected override string getErrorMessage() => nameof(SectionsShouldNotDiffer);

        protected override bool Test(Schedule local, Schedule remote)
        {

            return false;
        }

        private class ErrorMessage
        {
            private Section local, remote;
            public ErrorMessage(Section local, Section remote)
            {
                this.local = local;
                this.remote = remote;
            }

            public override string ToString()
            {
                return null;
            }
        }
        
    }
}
