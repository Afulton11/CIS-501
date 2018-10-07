using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Project1.Utility
{
    public abstract class BasePropertyChanged : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected void SetProperty<T>(ref T property, T value, [CallerMemberName] string propertyName = "")
        {
            if ((property == null && value == null) || (property != null && property.Equals(value))) return;
            property = value;
            OnPropertyChanged(propertyName);
        }
    }
}
