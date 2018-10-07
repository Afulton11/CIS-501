using System;

namespace Project1.Scheduler
{
    public class SchedulerPresenter
    {
        private SchedulerViewModel _viewModel;

        public SchedulerPresenter(ISchedulerView view)
        {
            SubscribeToView(view);
            _viewModel = view.ViewModel;
        }

        private void SubscribeToView(ISchedulerView view)
        {
            view.VerifyScheduleEvent += View_VerifyScheduleEvent;
            view.ReloadEvent += View_ReloadEvent;
            view.ClearEvent += View_ClearEvent;
            view.AboutEvent += View_AboutEvent;

        }
        private void View_VerifyScheduleEvent(object sender, EventArgs e)
        {
            _viewModel.ConsoleText += "Verifying Schedules!\n";
        }

        private void View_ReloadEvent(object sender, EventArgs e)
        {
            _viewModel.ConsoleText += "Reloading!\n";
        }

        private void View_ClearEvent(object sender, EventArgs e)
        {
            _viewModel.ConsoleText += "Clearing!\n";
        }

        private void View_AboutEvent(object sender, EventArgs e)
        {
            _viewModel.ConsoleText += "About!\n";
        }
    }
}
