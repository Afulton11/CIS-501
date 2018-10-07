using Project1.Entities;
using Project1.Scheduler;

namespace Project1.Verification
{
    public abstract class ScheduleConstraint : IScheduleConstraint
    {
        public abstract IConsoleViewModel ConsoleViewModel { get; }

        public bool Verify(Schedule localSchedule, Schedule remoteSchedule)
        {
            if (DoSchedulesPass(localSchedule, remoteSchedule))
                return true;
            ConsoleViewModel.ConsoleText += ErrorMessageFormat + "\n";
            return false;
        }

        protected abstract string ErrorMessageFormat { get; }

        protected abstract bool DoSchedulesPass(Schedule localSchedule, Schedule remoteSchedule);
    }
}
