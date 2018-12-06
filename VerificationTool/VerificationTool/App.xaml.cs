using System;
using System.Windows;
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
            SchedulerPresenter presenter = new SchedulerPresenter(
                viewModel,
                view,
                title => new Microsoft.Win32.OpenFileDialog()
                {
                    Filter = "CSV Files (*.csv)|*.csv",
                    Title = title,
                    Multiselect = false,
                });

            app.Run(view);
        }
    }
}
