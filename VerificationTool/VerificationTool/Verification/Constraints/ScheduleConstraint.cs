using VerificationTool.Entities;

namespace VerificationTool.Verification.Constraints
{
    public abstract class ScheduleConstraint : IScheduleConstraint
    {
        public string Error { get; private set; }

        public bool Verify(Schedule local, Schedule remote)
        {
            if (Test(local, remote))
                return true;
            else
            {
                Error = getErrorMessage();
                return false;
            }
        }

        protected abstract bool Test(Schedule local, Schedule remote);

        protected abstract string getErrorMessage();

    }
}
