using System.Collections.Specialized;
using System.ComponentModel;

namespace MonitorWPF.Models
{
    class EnvironmentModel:INotifyPropertyChanged
    {
        private string _enItemName;
        private string _enItemValue;
        public string EnItemName
        {
            get=> _enItemName;
            set { _enItemName = value; OnPropertyChanged(nameof(EnItemName)); }
        }
        public string EnItemValue {
        get=>_enItemValue;
            set { _enItemValue = value;OnPropertyChanged(nameof(EnItemValue)); }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
