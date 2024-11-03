namespace MonitorWPF.Models
{
    class WorkShopModel
    {
        public string WorkShopName { get; set; }
        public int WorkShopCount { get; set; }
        public int WaitCount { get; set; }
        public int WorngCount { get; set; }
        public int StopCount { get; set; }
        public int TotalCount
        {
            get
            {
                return WorkShopCount + WaitCount + WorngCount + StopCount;
            }
        }
    }
}
