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
        public event EventHandler AboutEvent;
        public event EventHandler ClearEvent;
        public event EventHandler ReloadEvent;
        public event EventHandler LoadLocalScheduleEvent;
        public event EventHandler VerifySchedulesEvent;

        public SchedulerView(ISchedulerViewModel viewModel)
        {
            ViewModel = viewModel;
            
            AboutCommand = new RelayCommand(sender => AboutEvent.Invoke(sender, null));
            ClearCommand = new RelayCommand(sender => ClearEvent.Invoke(sender, null));
            ReloadCommand = new RelayCommand(sender => ReloadEvent.Invoke(sender, null));
            LoadLocalScheduleCommand = new RelayCommand(sender => LoadLocalScheduleEvent.Invoke(sender, null));
            VerifySchedulesCommand = new RelayCommand(sender => VerifySchedulesEvent.Invoke(sender, null), _ => CanVerifySchedules());

            InitializeComponent();
        }

        public ISchedulerViewModel ViewModel { get; }
        public ICommand AboutCommand { get; }
        public ICommand ClearCommand { get; }
        public ICommand ReloadCommand { get; }
        public ICommand LoadLocalScheduleCommand { get; }
        public ICommand VerifySchedulesCommand { get; }

        private bool CanVerifySchedules() => !string.IsNullOrEmpty(ViewModel.LocalPath);

        
    }
}
