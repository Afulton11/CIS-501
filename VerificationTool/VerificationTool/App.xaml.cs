using System;
using System.Collections.Generic;
using System.Windows;
using VerificationTool.Verification.Constraints;
using VerificationTool.Verification.Constraints.Impl;
using VerificationTool.Verification.Readers;
using VerificationTool.Views.Scheduler;

namespace VerificationTool
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        App()
        {
            InitializeComponent();
        }

        [STAThread]
        static void Main()
        {
            App app = new App();
            ISchedulerViewModel viewModel = new SchedulerViewModel();
            SchedulerView view = new SchedulerView(viewModel);

            IScheduleReader scheduleReader = new CSVScheduleReader();
            IEnumerable<IScheduleConstraint> scheduleConstraints = GetScheduleConstraints();
            SchedulerPresenter presenter = new SchedulerPresenter(
                viewModel,
                view,
                title => new Microsoft.Win32.OpenFileDialog()
                {
                    Filter = "CSV Files (*.csv)|*.csv",
                    Title = title,
                    Multiselect = false,
                },
                scheduleReader,
                scheduleConstraints);

            app.Run(view);
        }

        static IEnumerable<IScheduleConstraint> GetScheduleConstraints()
        {
            yield return new LocalSectionsRequired();
            yield return new RemoteSectionsRequired();
            yield return new SectionsShouldNotDiffer();
        }

    }
}
