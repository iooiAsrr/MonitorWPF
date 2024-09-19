using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MonitorWPF.ViewModels
{
    class MainWindowVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        private UserControl _MonitorUC;
        /// <summary>
        /// 监控用户控件
        /// </summary>

        public UserControl MonitorUC
        {
            get
            {
                if (_MonitorUC == null)
                {
                    _MonitorUC = new UserControls.MonitorUC();
                }
                return _MonitorUC;
            }
            set
            {
                _MonitorUC = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("MonitorUC"));
                }
            }
        }
        //时间
        public string TimeStr
        {
            get => DateTime.Now.ToString("HH:mm");
        }
        public string DateStr
        {
            get => DateTime.Now.ToString("yyyy-MM-dd");
        }

        public string WeekDayStr
        {
            get
            {
                int index = (int)DateTime.Now.DayOfWeek;
                return new string[7] { "星期日", "星期一", "星期二", "星期三", "星期四", "星期五", "星期六" }[index];
            }
        }
        private string _MachineCount = "0134";

        public string MachineCount
        {
            get { return _MachineCount; }
            set
            {
                _MachineCount = value;
                if (_MachineCount != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("MachineCount"));
                }
            }
        }
        private string _ProductCount = "9999";

        public string ProductCount
        {
            get { return _ProductCount; }
            set
            {
                _ProductCount = value;
                if (_ProductCount != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("ProductCount"));
                }
            }
        }private string _BadCount = "0132";

        public string BadCount
        {
            get { return _BadCount; }
            set
            {
                _BadCount = value;
                if (_BadCount != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("BadCount"));
                }
            }
        }

    }
}
