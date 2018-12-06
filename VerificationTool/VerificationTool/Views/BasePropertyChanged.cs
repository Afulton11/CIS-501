using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace VerificationTool.Views
{
    public class BasePropertyChanged : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void SetProperty<T>(ref T oldValue, T newValue, [CallerMemberName] string property = "")
        {
            if (object.Equals(oldValue, newValue))
            {
                return;
            }

            oldValue = newValue;
            this.OnPropertyChanged(property);
        }

        protected virtual void OnPropertyChanged(string property)
        {
            var eventHandler = this.PropertyChanged;
            if (eventHandler != null)
            {
                eventHandler(this, new PropertyChangedEventArgs(property));
            }
        }
    }
}
