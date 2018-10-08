using Project1.Entities;
using Project1.Scheduler.Console;
using Project1.Verification.Constraint;
using System;

namespace Project1.Verification.Constraints
{
    public class LocalSectionsShouldNotDiffer : ScheduleConstraint
    {
        public LocalSectionsShouldNotDiffer(IConsoleViewModel viewModel) : base(viewModel)
        {
        }

        public override bool Verify(Schedule localSchedule, Schedule remoteSchedule)
        {
            throw new NotImplementedException();
        }

        protected override string ErrorMessageFormat => throw new NotImplementedException();
    }
}
