using VerificationTool.Entities;

namespace VerificationTool.Verification.Constraints
{
    public abstract class ScheduleConstraint : IScheduleConstraint
    {
        public string Error { get; private set; }

        public bool Verify(Semester local, Semester remote)
        {
            if (Test(local, remote))
                return true;
            else
            {
                Error = getErrorMessage();
                return false;
            }
        }

        protected abstract bool Test(Semester local, Semester remote);

        protected abstract string getErrorMessage();

    }
}
