using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace MonitorWPF.UserControls
{
    /// <summary>
    /// RingUC.xaml 的交互逻辑
    /// </summary>
    public partial class RingUC : UserControl
    {
        public RingUC()
        {
            InitializeComponent();
            SizeChanged += RingUC_SizeChanged;//界面大小改变时触发
        }
        public double PercentValue
        {
            get { return (double)GetValue(PercentValueProperty); }
            set { SetValue(PercentValueProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PercentValue.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PercentValueProperty =
            DependencyProperty.Register("PercentValue", typeof(double), typeof(RingUC));
        //画圆环
        private void Drug()
        {
            LayOut.Width = Math.Min(RenderSize.Width, RenderSize.Height);
            double raduis = LayOut.Width / 2;

            double x = raduis + (raduis - 3) * Math.Cos((PercentValue % 100 * 3.6 - 90) * Math.PI / 180);
            double y = raduis + (raduis - 3) * Math.Sin((PercentValue % 100 * 3.6 - 90) * Math.PI / 180);

            int Is50 = PercentValue < 50 ? 0 : 1;

            //M:移动  A:画弧
            string pathStr = $"M{raduis + 0.01} 3A{raduis - 3} {raduis - 3} 0 {Is50} 1 {x} {y}";//移动路径

            //几何图形对象
            var converter = TypeDescriptor.GetConverter(typeof(Geometry));
            path.Data = (Geometry)converter.ConvertFrom(pathStr);
        }
        private void RingUC_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            Drug();
        }

    }
}
