using Microsoft.Win32;
using Project1.Utility;
using System;
using System.Windows;
using System.Windows.Input;

namespace Project1.Scheduler
{
    /// <summary>
    /// Interaction logic for SchedulerView.xaml
    /// </summary>
    public partial class SchedulerView : Window, ISchedulerView
    {
        public event EventHandler VerifyScheduleEvent;
        public event EventHandler ClearEvent;
        public event EventHandler ReloadEvent;
        public event EventHandler AboutEvent;

        public SchedulerView()
        {
            LoadLocalFileCommand = new RelayCommand(OnLoadLocalFile);
            LoadRemoteFileCommand = new RelayCommand(OnLoadRemoteFile);
            ReloadCommand = new RelayCommand(OnReload);
            ClearCommand = new RelayCommand(OnClear);
            AboutCommand = new RelayCommand(OnAbout);

            ViewModel = new SchedulerViewModel();
            
            InitializeComponent();
        }

        public SchedulerViewModel ViewModel { get; private set; }

        public ICommand LoadLocalFileCommand { get; set; }
        public ICommand LoadRemoteFileCommand { get; set; }
        public ICommand ReloadCommand { get; set; }
        public ICommand ClearCommand { get; set; }
        public ICommand AboutCommand { get; set; }

        public void OnLoadLocalFile(object source)
        {
            var filepath = RetrieveCSVFileFromUser();
            if (!string.IsNullOrEmpty(filepath))
            {
                ViewModel.LocalSchedulePath = filepath;
            }
        }

        public void OnLoadRemoteFile(object source)
        {
            var filepath = RetrieveCSVFileFromUser();
            if (!string.IsNullOrEmpty(filepath))
            {
                ViewModel.RemoteSchedulePath = filepath;
            }

            if (!string.IsNullOrEmpty(ViewModel.LocalSchedulePath))
            {
                VerifyScheduleEvent?.Invoke(source, null);
            }
        }

        public void OnReload(object source) => ReloadEvent?.Invoke(source, null);

        public void OnClear(object source) => ClearEvent?.Invoke(source, null);

        public void OnAbout(object source) => AboutEvent?.Invoke(source, null);

        private string RetrieveCSVFileFromUser()
        {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.DefaultExt = ".csv";
            openFileDialog.Filter = "CSV Files (*.csv)|*.csv";

            if (openFileDialog.ShowDialog() == true)
            {
                return openFileDialog.FileName;
            }

            return null;
        }
    }
}
