using VerificationTool.utilities;

namespace VerificationTool.Views.Scheduler
{
    public class SchedulerViewModel : BasePropertyChanged, ISchedulerViewModel
    {
        private string _localPath, _remotePath;
        private string _consoleText;

        public string LocalPath {
            get => _localPath;
            set => SetProperty(ref _localPath, value);
        }
        
        public string RemotePath {
            get => _remotePath;
            set => SetProperty(ref _remotePath, value);
        }
        public string ConsoleText {
            get => _consoleText;
            set => SetProperty(ref _consoleText, value);
        }

        public void WriteLine(string line) => ConsoleText = StringUtility.AddLine(ConsoleText, line);
    }
}
