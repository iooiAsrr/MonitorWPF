using MonitorWPF.Commands;
using MonitorWPF.UserControls;
using MonitorWPF.ViewModels;
using MonitorWPF.Views;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MonitorWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainWindowVM mainWindowVM = new();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = mainWindowVM;
        }
        //控件切换
        private void ShowDetailUC()
        {
            WorkDetail workDetail = new();
            mainWindowVM.MonitorUC = workDetail;
            //过度动画
            ThicknessAnimation thicknessAnimation = new(new Thickness(0, 500, 0, -100), new Thickness(0, 0, 0, 0), new TimeSpan(0, 0, 0, 0, 500));
            //设置动画的缓动效果
            DoubleAnimation doubleAnimation = new DoubleAnimation(0, 1, new TimeSpan(0, 0, 0, 0, 500));

            Storyboard.SetTarget(thicknessAnimation, workDetail);
            Storyboard.SetTarget(doubleAnimation, workDetail);

            Storyboard.SetTargetProperty(thicknessAnimation, new PropertyPath("Margin"));
            Storyboard.SetTargetProperty(doubleAnimation, new PropertyPath("Opacity"));

            Storyboard storyboard = new();
            storyboard.Children.Add(thicknessAnimation);
            storyboard.Children.Add(doubleAnimation);
            storyboard.Begin();
        }
        public Command ShowDetailCmm
        {
            get
            {
                return new Command(ShowDetailUC);
            }
        }
        private void GoBack()
        {
            MonitorUC monitorUC = new MonitorUC();
            mainWindowVM.MonitorUC = monitorUC;
            //过度动画
            ThicknessAnimation thicknessAnimation = new(new Thickness(0, 500, 0, -100), new Thickness(0, 0, 0, 0), new TimeSpan(0, 0, 0, 0, 500));
            //设置动画的缓动效果
            DoubleAnimation doubleAnimation = new DoubleAnimation(0, 1, new TimeSpan(0, 0, 0, 0, 500));

            Storyboard.SetTarget(thicknessAnimation, monitorUC);
            Storyboard.SetTarget(doubleAnimation, monitorUC);

            Storyboard.SetTargetProperty(thicknessAnimation, new PropertyPath("Margin"));
            Storyboard.SetTargetProperty(doubleAnimation, new PropertyPath("Opacity"));

            Storyboard storyboard = new();
            storyboard.Children.Add(thicknessAnimation);
            storyboard.Children.Add(doubleAnimation);
            storyboard.Begin();
        }
        public Command GoBackCm
        {
            get
            {
                return new Command(GoBack);
            }
        }


        //最小最大化按钮
        private void Button_Click(object sender, RoutedEventArgs e) => this.WindowState = WindowState.Minimized;
        //private void Button_Click_1(object sender, RoutedEventArgs e) => this.WindowState = WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;
        private void Button_click_2(object sender, RoutedEventArgs e) => this.Close();
        //显示配置窗口
        private void ShowSettingWindow()
        {
            Setting Setting = new() { Owner = this };
            Setting.ShowDialog();
        }
        public Command ShowSettingWindowCmm
        {
            get
            {
                return new Command(ShowSettingWindow);
            }
        }
    }
}