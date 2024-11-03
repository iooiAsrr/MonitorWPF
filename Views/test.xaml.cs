using Modbus.Device;
using System.IO.Ports;
using System.Windows;
using System.Windows.Controls;

namespace MonitorWPF.Views
{
    /// <summary>
    /// test.xaml 的交互逻辑
    /// </summary>
    public partial class test : Page
    {
        public test()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (SerialPort serialPort = new SerialPort("COM2", 9600, Parity.None, 8, StopBits.One))
            {
                serialPort.Open();
                IModbusMaster master = ModbusSerialMaster.CreateRtu(serialPort);
                ushort[] result = master.ReadHoldingRegisters(1, 0, 10);
                master.WriteMultipleRegisters(1, 0, new ushort[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });
            }
        }
    }
}
