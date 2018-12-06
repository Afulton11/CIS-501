using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using VerificationTool.Entities;
using VerificationTool.Verification.Constraints;
using VerificationTool.Verification.Readers;

namespace VerificationTool.Views.Scheduler
{
    public class SchedulerPresenter
    {
        private readonly ISchedulerViewModel viewModel;
        private readonly Func<string, OpenFileDialog> openFileDialog;
        private readonly IScheduleReader scheduleReader;
        private readonly IEnumerable<IScheduleConstraint> scheduleConstraints;

        private Semester localSchedule, remoteSchedule;

        public SchedulerPresenter(
            ISchedulerViewModel viewModel,
            ISchedulerView view,
            Func<string, OpenFileDialog> openFileDialog,
            IScheduleReader scheduleReader,
            IEnumerable<IScheduleConstraint> scheduleConstraints)
        {
            this.viewModel = viewModel;
            this.openFileDialog = openFileDialog;
            this.scheduleReader = scheduleReader;
            this.scheduleConstraints = scheduleConstraints;

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
            localSchedule = null;
            remoteSchedule = null;
            viewModel.LocalPath = "";
            viewModel.RemotePath = "";
        }

        private void OnReload()
        {
            viewModel.WriteLine("OnReload();");
            localSchedule = ReadSchedule(viewModel.LocalPath);
            remoteSchedule = ReadSchedule(viewModel.RemotePath);

            if (localSchedule != null && remoteSchedule != null)
                VerifySchedules();
        }

        private void OnLoadLocalSchedule()
        {
            var localFilepath = RetrieveFilepath("Choose a Remote File");
            var schedule = ReadSchedule(localFilepath);

            if (schedule != null)
            {
                localSchedule = schedule;
                viewModel.RemotePath = localFilepath;
            }
        }

        private void OnVerifySchedules()
        {
            var remoteFilepath = RetrieveFilepath("Choose a Remote File");                
            var schedule = ReadSchedule(remoteFilepath);

            if (schedule != null)
            {
                remoteSchedule = schedule;
                viewModel.RemotePath = remoteFilepath;
                VerifySchedules();
            }
        }

        private Semester ReadSchedule(string filepath)
        {
            if (IsValidFile(filepath))
                return scheduleReader.Read(filepath);
            else
            {
                viewModel.WriteLine("[ERROR]: Please select a valid file.");
                return null;
            }
        }

        private bool IsValidFile(string filepath) => !string.IsNullOrEmpty(filepath) && File.Exists(filepath);

        private string RetrieveFilepath(string title)
        {
            var dialog = openFileDialog(title);

            bool? dialogResult = dialog.ShowDialog();

            if (dialogResult ?? false)
                return dialog.FileName;

            return null;
        }

        private void VerifySchedules()
        {
            bool DidError = false;
            foreach (var constraint in scheduleConstraints)
            {
                if (!constraint.Verify(localSchedule, remoteSchedule))
                {
                    viewModel.WriteLine(constraint.Error);
                    DidError = true;
                }
            }

            if (!DidError)
                viewModel.WriteLine("The local and remote schedules were successfully verified!");
        }
    }
}
