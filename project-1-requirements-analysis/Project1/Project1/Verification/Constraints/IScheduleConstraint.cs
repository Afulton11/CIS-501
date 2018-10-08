using Project1.Entities;

namespace Project1.Verification.Constraint
{
    public interface IScheduleConstraint
    {
        bool Verify(Schedule localSchedule, Schedule remoteSchedule);
    }

}
