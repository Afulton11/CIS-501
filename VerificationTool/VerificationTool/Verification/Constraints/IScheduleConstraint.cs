using VerificationTool.Entities;

namespace VerificationTool.Verification.Constraints
{
    public interface IScheduleConstraint
    {
        bool Verify(Schedule local, Schedule remote);
        string Error { get; }
    }
}
