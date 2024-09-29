using MonitorWPF.Models;
using MonitorWPF.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Numerics;
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
            #region 初始化报警信息
            AlarmList = new List<AlarmModel>()
            {
                new AlarmModel(){AlarmTime="07-01 12:00:00",AlarmContent="温度过高",AlarmLevel="严重"},
                new AlarmModel(){AlarmTime="07-01 12:00:00",AlarmContent="湿度过高",AlarmLevel="严重"},
                new AlarmModel(){AlarmTime="07-01 12:00:00",AlarmContent="气压过高",AlarmLevel="严重"},
                new AlarmModel(){AlarmTime="07-01 12:00:00",AlarmContent="风速过高",AlarmLevel="严重"},
                new AlarmModel(){AlarmTime="07-01 12:00:00",AlarmContent="PM2.5过高",AlarmLevel="严重"},
                new AlarmModel(){AlarmTime="07-01 12:00:00",AlarmContent="噪音过高",AlarmLevel="严重"},
            };
            #endregion
            #region 初始化设备列表
            DeviceList = new List<DeviceModel>()
            {
                new DeviceModel(){DeviceItem="电压",Value="220V"},
                new DeviceModel(){DeviceItem="电流",Value="2A"},
                new DeviceModel(){DeviceItem="温度",Value="48"},
                new DeviceModel(){DeviceItem="压力",Value="84%"},
                new DeviceModel(){DeviceItem="转速",Value="4800"},
            };
            #endregion
            #region 定义雷达数据
            RaderList = new List<RaderModel>()
            {
                new RaderModel(){ItemName="温度",Value=80},
                new RaderModel(){ItemName="噪音",Value=60},
                new RaderModel(){ItemName="设备3",Value=32},
                new RaderModel(){ItemName="设备4",Value=90},
                new RaderModel(){ItemName="设备5",Value=15},
                new RaderModel(){ItemName="设备5",Value=35},
                new RaderModel(){ItemName="设备5",Value=55},
            };
            #endregion
            #region 初始员工事件
            WorkerList = new List<WorkerModel>()
            {
                new WorkerModel(){Id=132 ,Name="张三",OutWork=31},
                new WorkerModel(){Id=243 ,Name="李四",OutWork=10},
                new WorkerModel(){Id=342 ,Name="王五",OutWork=42},
                new WorkerModel(){Id=121 ,Name="赵六",OutWork=38},
                new WorkerModel(){Id=234 ,Name="孙七",OutWork=48},
            };
            #endregion
            #region 车间信息
            WorkShopList = new List<WorkShopModel>()
            {
                new WorkShopModel(){WorkShopName="车间1",WorkShopCount=23,WaitCount=24,WorngCount=12,StopCount=25},
                new WorkShopModel(){WorkShopName="车间2",WorkShopCount=21,WaitCount=22,WorngCount=12,StopCount=21},
                new WorkShopModel(){WorkShopName="车间3",WorkShopCount=23,WaitCount=32,WorngCount=12,StopCount=21},
            };
            #endregion
            #region 初始化机台详细数据
            MachineList = new List<MachineDataModel>();
            Random random = new();
            for (int i = 0; i < 20; i++)
            {
                int plan = random.Next(100, 1000);
                int complete = random.Next(0, plan);
                MachineList.Add(new MachineDataModel
                {
                    MachineName = $"机台{i + 1}",
                    MachineStatus = complete == plan ? "生产完成" : "生产中",
                    PlanCount = plan,
                    FinishedCount = complete,
                    OrderNo = $"A00{i + 1}",
                });
            }
            MachineList.Add(new MachineDataModel
            {
                MachineName = "机台",
                MachineStatus = "生产完成",
                PlanCount = 120,
                FinishedCount = 120,
                OrderNo = "hg",
            });
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
        #region 报警信息
        private List<AlarmModel> _AlarmList;

        public List<AlarmModel> AlarmList
        {
            get { return _AlarmList; }
            set
            {
                _AlarmList = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("AlarmList"));
                }
            }
        }
        #endregion
        #region 设备列表
        private List<DeviceModel> _DeviceList;

        public List<DeviceModel> DeviceList
        {
            get { return _DeviceList; }
            set
            {
                _DeviceList = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("DeviceList"));
                }
            }
        }


        #endregion
        #region 雷达数据
        private List<RaderModel> _RaderList;

        public List<RaderModel> RaderList
        {
            get { return _RaderList; }
            set
            {
                _RaderList = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("RaderList"));
                }
            }
        }
        #endregion
        #region 员工事件
        private List<WorkerModel> _WorkerList;

        public List<WorkerModel> WorkerList
        {
            get { return _WorkerList; }
            set
            {
                _WorkerList = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("WorkerList"));
                }
            }
        }
        #endregion
        #region 车间信息
        private List<WorkShopModel> _WorkShopList;

        public List<WorkShopModel> WorkShopList
        {
            get { return _WorkShopList; }
            set
            {
                _WorkShopList = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("WorkShopList"));
                }
            }
        }

        #endregion
        #region 机台详细数据
        private List<MachineDataModel> _MachineList;

        public List<MachineDataModel> MachineList
        {
            get { return _MachineList; }
            set { _MachineList = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("MachineList"));
                }
            }
        }

        #endregion
    }
}
