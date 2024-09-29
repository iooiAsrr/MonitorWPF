using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MonitorWPF.Views
{
    /// <summary>
    /// Setting.xaml 的交互逻辑
    /// </summary>
    public partial class Setting : Window
    {
        public Setting()
        {
            InitializeComponent();
        }
        //导航到相应的label标签页面
        private void labelDetail(object sender,RoutedEventArgs e)
        {
            frame.Navigate(new Uri("pack://application:,,,/MonitorWPF;component/Views/SettingPage.xaml#"+(sender as RadioButton)?.Tag.ToString(), UriKind.Absolute));
            //程序集（授权） 路径 都在一起
            //frame.Navigate(new Uri("pack://application:,,,/Views/SettingPage.xaml", UriKind.Absolute));
        }
    }
}
