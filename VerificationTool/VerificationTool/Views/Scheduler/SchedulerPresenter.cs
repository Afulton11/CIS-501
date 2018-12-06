using Microsoft.Win32;
using System;
using VerificationTool.Verification.Readers;

namespace VerificationTool.Views.Scheduler
{
    public class SchedulerPresenter
    {
        private readonly ISchedulerViewModel viewModel;
        private readonly Func<string, OpenFileDialog> openFileDialog;
        private readonly IScheduleReader scheduleReader;

        public SchedulerPresenter(
            ISchedulerViewModel viewModel,
            ISchedulerView view,
            Func<string, OpenFileDialog> openFileDialog,
            IScheduleReader scheduleReader)
        {
            this.viewModel = viewModel;
            this.openFileDialog = openFileDialog;
            this.scheduleReader = scheduleReader;

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
            viewModel.LocalPath = "";
            viewModel.RemotePath = "";
        }

        private void OnReload()
        {
            viewModel.WriteLine("OnReload();");
        }

        private void OnLoadLocalSchedule()
        {
            var localFilepath = RetrieveFilepath("Choose a Remote File");

            if (WasFileChosen(localFilepath))
                viewModel.RemotePath = localFilepath;
            else
            {
                viewModel.WriteLine("[ERROR]: You didn't select a valid local filepath.");
                return;
            }
        }

        private void OnVerifySchedules()
        {
            var localFilepath = RetrieveFilepath("Choose a Remote File");

            if (WasFileChosen(localFilepath))
                viewModel.RemotePath = localFilepath;
            else
            {
                viewModel.WriteLine("[ERROR]: Please choose a remote file path before verifying a schedule.");
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
            var dialog = openFileDialog(title);

            bool? dialogResult = dialog.ShowDialog();

            if (dialogResult ?? false)
                return dialog.FileName;

            return null;
        }
    }
}
