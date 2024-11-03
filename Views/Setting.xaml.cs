using System.Windows;
using System.Windows.Controls;

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
        private void labelDetail(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new Uri("pack://application:,,,/MonitorWPF;component/Views/SettingPage.xaml#" + (sender as RadioButton)?.Tag.ToString(), UriKind.Absolute));
            //程序集（授权） 路径 都在一起
            //frame.Navigate(new Uri("pack://application:,,,/Views/SettingPage.xaml", UriKind.Absolute));
        }
    }
}
