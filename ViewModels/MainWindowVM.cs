using MonitorWPF.Models;
using MonitorWPF.UserControls;
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
        public MainWindowVM()
        {
            #region 初始化环境监控数据
            EnvironmentList = new List<EnvironmentModel>()
            {
                new EnvironmentModel(){EnItemName="温度",EnItemValue="26℃"},
                new EnvironmentModel(){EnItemName="湿度",EnItemValue="50%"},
                new EnvironmentModel(){EnItemName="气压",EnItemValue="1013hPa"},
                new EnvironmentModel(){EnItemName="风速",EnItemValue="2m/s"},
                new EnvironmentModel(){EnItemName="风向",EnItemValue="东南风"},
                new EnvironmentModel(){EnItemName="PM2.5",EnItemValue="25ug/m³"},
                new EnvironmentModel(){EnItemName="噪音",EnItemValue="50dB"},
            };
            #endregion
        }

        private UserControl _MonitorUC = new UserControls.MonitorUC();
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
        #region 时间日期
        //时间
        public string TimeStr
        {
            get => DateTime.Now.ToString("HH:mm");
        }
        public string DateStr
        {
            get => DateTime.Now.ToString("yyyy-MM-dd");
        }
        #endregion
        #region 产能计数
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
        private string _ProductCount = "9453";

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
        }
        private string _BadCount = "0132";

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
        #endregion
        #region 环境监控数据
        private List<EnvironmentModel> _EnvironmentList;
        public List<EnvironmentModel> EnvironmentList
        {
            get
            {
                return _EnvironmentList;
            }
            set
            {
                _EnvironmentList = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("EnvironmentList"));
                }
            }
        }
        #endregion
    }
}
