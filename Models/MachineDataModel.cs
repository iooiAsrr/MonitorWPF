using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitorWPF.Models
{
    internal class MachineDataModel
    {
        //机器名
        public string MachineName { get; set; }
        //机器状态
        public string MachineStatus { get; set; }
        public string MachineStatusColor
        {
            get
            {
                return MachineStatus == "生产中" ? "Green" : "Red";
            }
        }
        //计划数量
        public int PlanCount { get; set; }
        //已完成数量
        public int FinishedCount { get; set; }
        //工单编号
        public string OrderNo { get; set; }
        public double Percent
        {
            get
            {
                return FinishedCount * 100.0 / PlanCount;
            }
        }
    }
}
