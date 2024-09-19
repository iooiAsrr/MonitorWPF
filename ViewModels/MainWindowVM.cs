using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MonitorWPF.ViewModels
{
    class MainWindowVM:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        private UserControl _MonitorUC;
		/// <summary>
		/// 监控用户控件
		/// </summary>

		public UserControl MonitorUC
        {
			get { 
                if(_MonitorUC == null)
                {
                    _MonitorUC = new UserControls.MonitorUC();
                }
                return _MonitorUC; }
			set { _MonitorUC = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("MonitorUC"));
                } 
            }
		}

        
    }
}
