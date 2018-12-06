using VerificationTool.Entities;

namespace VerificationTool.Verification.Constraints
{
    public interface IScheduleConstraint
    {
        bool Verify(Semester local, Semester remote);
        string Error { get; }
    }
}
