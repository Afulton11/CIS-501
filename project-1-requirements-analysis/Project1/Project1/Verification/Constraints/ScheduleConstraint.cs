using Project1.Entities;
using Project1.Scheduler.Console;

namespace Project1.Verification.Constraint
{
    public abstract class ScheduleConstraint : IScheduleConstraint
    {
        private readonly IConsoleViewModel _consoleViewModel;
    
        public ScheduleConstraint(IConsoleViewModel viewModel)
        {
            _consoleViewModel = viewModel;
        }

        public abstract bool Verify(Schedule localSchedule, Schedule remoteSchedule);

        protected abstract string ErrorMessageFormat { get; }

        protected void WriteErrorMessage(params object[] values) => _consoleViewModel.WriteLine(ErrorMessageFormat, values);
    }
}
