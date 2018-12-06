using Microsoft.Win32;
using System;

namespace VerificationTool.Views.Scheduler
{
    public class SchedulerPresenter
    {
        private readonly ISchedulerViewModel _viewModel;
        private readonly Func<string, OpenFileDialog> _openFileDialog;

        public SchedulerPresenter(
            ISchedulerViewModel viewModel,
            ISchedulerView view,
            Func<string, OpenFileDialog> openFileDialog)
        {
            _viewModel = viewModel;
            _openFileDialog = openFileDialog;
            SubscribeToView(view);
        }

        void SubscribeToView(ISchedulerView view)
        {
            // we need to subscribe to the view's events, but there is never any need to unsubscribe as this presenter
            // lives for the same time as the view. (until the application ends)
            view.ClearEvent += (_, __) => OnClear();
            view.ReloadEvent += (_, __) => OnReload();
            view.LoadLocalScheduleEvent += (_, __) => OnLoadLocalSchedule();
            view.VerifySchedulesEvent += (_, __) => OnVerifySchedules();
        }

        private void OnClear()
        {
            _viewModel.LocalPath = "";
            _viewModel.RemotePath = "";
        }

        private void OnReload()
        {
            _viewModel.WriteLine("OnReload();");
        }

        private void OnLoadLocalSchedule()
        {
            var localFilepath = RetrieveFilepath("Choose a Remote File");

            if (WasFileChosen(localFilepath))
                _viewModel.RemotePath = localFilepath;
            else
            {
                _viewModel.WriteLine("[ERROR]: You didn't select a valid local filepath.");
                return;
            }
        }

        private void OnVerifySchedules()
        {
            var localFilepath = RetrieveFilepath("Choose a Remote File");

            if (WasFileChosen(localFilepath))
                _viewModel.RemotePath = localFilepath;
            else
            {
                _viewModel.WriteLine("[ERROR]: Please choose a remote file path before verifying a schedule.");
                return;
            }
        }

        private object LoadFile(string filepath)
        {
            return null;
        }

        private bool WasFileChosen(string filepath) => !string.IsNullOrEmpty(filepath);

        private string RetrieveFilepath(string title)
        {
            var dialog = _openFileDialog(title);

            bool? dialogResult = dialog.ShowDialog();

            if (dialogResult ?? false)
                return dialog.FileName;

            return null;
        }
    }
}
