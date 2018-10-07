using Project1.Entities;
using Project1.Scheduler;

namespace Project1.Verification
{
    public interface IScheduleConstraint
    {
        IConsoleViewModel ConsoleViewModel { get; }
        bool Verify(Schedule localSchedule, Schedule remoteSchedule);
    }

}
