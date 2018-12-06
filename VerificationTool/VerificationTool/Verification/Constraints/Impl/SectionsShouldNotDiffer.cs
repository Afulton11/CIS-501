using System;
using System.Collections.Generic;
using System.Linq;
using VerificationTool.Entities;

namespace VerificationTool.Verification.Constraints.Impl
{
    public class SectionsShouldNotDiffer : ScheduleConstraint
    {

        private ErrorMessage error;

        protected override string getErrorMessage() => error?.ToString();

        protected override bool Test(Semester local, Semester remote)
        {
            var localSchedule = local.Schedule;
            var remoteSchedule = remote.Schedule;

            //return TestSections(localSchedule, remoteSchedule);
            
            return false;
        }

        private bool TestSections(IList<Course> localSchedule, IList<Section> remoteSchedule)
        {
            foreach (var localCourse in localSchedule)
            {
                foreach (var remoteCourse in remoteSchedule)
                {
                    
                }
            }

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
