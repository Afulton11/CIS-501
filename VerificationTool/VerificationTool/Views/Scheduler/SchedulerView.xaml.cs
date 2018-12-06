using System;
using System.Windows;
using System.Windows.Input;
using VerificationTool.utilities;

namespace VerificationTool.Views.Scheduler
{
    /// <summary>
    /// Interaction logic for SchedulerView.xaml
    /// </summary>
    public partial class SchedulerView : Window, ISchedulerView
    {
        public event EventHandler VerifySchedulesEvent;
        public event EventHandler ClearEvent;
        public event EventHandler ReloadEvent;
        public event EventHandler LoadLocalScheduleEvent;

        public SchedulerView(ISchedulerViewModel viewModel)
        {
            ViewModel = viewModel;
            
            AboutCommand = new RelayCommand(_ => OnAbout());
            ClearCommand = new RelayCommand(sender => ClearEvent.Invoke(sender, null));
            ReloadCommand = new RelayCommand(sender => ReloadEvent.Invoke(sender, null));
            LoadLocalScheduleCommand = new RelayCommand(sender => LoadLocalScheduleEvent.Invoke(sender, null));
            VerifySchedulesCommand = new RelayCommand(sender => VerifySchedulesEvent.Invoke(sender, null));

            InitializeComponent();
        }

        public ISchedulerViewModel ViewModel { get; }
        public ICommand AboutCommand { get; }
        public ICommand ClearCommand { get; }
        public ICommand ReloadCommand { get; }
        public ICommand LoadLocalScheduleCommand { get; }
        public ICommand VerifySchedulesCommand { get; }

        private void OnAbout() => ViewModel.ConsoleText = StringUtility.AddLine(ViewModel.ConsoleText, "SVT Version 0.2.3. Last updated on 12/5/2018. Thanks for using SVT!");
    }
}
