using Project1.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Scheduler
{
    public sealed class SchedulerViewModel : BasePropertyChanged
    {
        private string _consoleText;
        private string _localSchedulePath;
        private string _remoteSchedulePath;

        public string ConsoleText
        {
            get => _consoleText;
            set => SetProperty(ref _consoleText, value);
        }

        public string LocalSchedulePath
        {
            get => _localSchedulePath;
            set => SetProperty(ref _localSchedulePath, value);
        }

        public string RemoteSchedulePath
        {
            get => _remoteSchedulePath;
            set => SetProperty(ref _remoteSchedulePath, value);
        }
    }
}
