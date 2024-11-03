using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace MonitorWPF.UserControls
{
    /// <summary>
    /// WorkDetail.xaml 的交互逻辑
    /// </summary>
    public partial class WorkDetail : UserControl
    {
        public WorkDetail()
        {
            InitializeComponent();
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            //位移
            detail.Visibility = Visibility.Visible;
            ThicknessAnimation thicknessAnimation = new(new Thickness(0, 50, 0, -50), new Thickness(0, 0, 0, 0), new TimeSpan(0, 0, 0, 0, 500));
            //透明度
            DoubleAnimation doubleAnimation = new(0, 1, new TimeSpan(0, 0, 0, 0, 500));
            Storyboard.SetTarget(thicknessAnimation, detailContent);
            Storyboard.SetTarget(doubleAnimation, detailContent);
            Storyboard.SetTargetProperty(thicknessAnimation, new PropertyPath("Margin"));
            Storyboard.SetTargetProperty(doubleAnimation, new PropertyPath("Opacity"));

            Storyboard storyboard = new();
            storyboard.Children.Add(thicknessAnimation);
            storyboard.Children.Add(doubleAnimation);
            storyboard.Begin();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ThicknessAnimation thicknessAnimation = new(new Thickness(0, 0, 0, 0), new Thickness(0, 50, 0, -50), new TimeSpan(0, 0, 0, 0, 500));
            //透明度
            DoubleAnimation doubleAnimation = new(1, 0, new TimeSpan(0, 0, 0, 0, 500));
            Storyboard.SetTarget(thicknessAnimation, detailContent);
            Storyboard.SetTarget(doubleAnimation, detailContent);
            Storyboard.SetTargetProperty(thicknessAnimation, new PropertyPath("Margin"));
            Storyboard.SetTargetProperty(doubleAnimation, new PropertyPath("Opacity"));

            Storyboard storyboard = new();
            storyboard.Children.Add(thicknessAnimation);
            storyboard.Children.Add(doubleAnimation);
            storyboard.Completed += (s, e) =>
            {
                detail.Visibility = Visibility.Collapsed;
            };
            storyboard.Begin();
        }
    }
}
