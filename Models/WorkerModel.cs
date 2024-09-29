using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitorWPF.Models
{
    class WorkerModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int OutWork { get; set; }
        public int OutWorkShow
        {
            get
            {
                return OutWork*80/100;
            }
        }
    }
}
