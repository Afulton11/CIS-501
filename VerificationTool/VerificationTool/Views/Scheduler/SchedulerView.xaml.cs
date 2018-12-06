using System;
using System.Windows;
using System.Windows.Input;

namespace VerificationTool.Views.Scheduler
{
    /// <summary>
    /// Interaction logic for SchedulerView.xaml
    /// </summary>
    public partial class SchedulerView : Window, ISchedulerView
    {
        public event EventHandler VerifyScheduleEvent;
        public event EventHandler ClearEvent;
        public event EventHandler ReloadEvent;
        public event EventHandler LoadLocalSchedulesEvent;

        public SchedulerView(ISchedulerViewModel viewModel)
        {
            ViewModel = viewModel;
            ClearCommand = new RelayCommand(sender => ClearEvent.Invoke(sender, null));
            ReloadCommand = new RelayCommand(sender => ReloadEvent.Invoke(sender, null));

            InitializeComponent();
        }

        public ISchedulerViewModel ViewModel { get; }
        public ICommand ClearCommand { get; set; }
        public ICommand ReloadCommand { get; set; }

    }
}
