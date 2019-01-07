using System;
using System.Collections.Generic;

namespace CH.Smart.Dal2.CommModels
{
    public partial class CommDataStat
    {
        public int DeviceId { get; set; }
        public DateTime? OfflineTime { get; set; }
        public byte DeviceState { get; set; }
        public decimal DataValue { get; set; }
        public DateTime? DataTime { get; set; }
        public DateTime UpdateTime { get; set; }
        public DateTime InitTime { get; set; }
        public bool NeedReQuery { get; set; }
        public DateTime? ReQueryTime { get; set; }
        public string LastInst { get; set; }
        public bool? PowerOn { get; set; }
        public decimal DataAvg { get; set; }
        public decimal AdjValue { get; set; }
        public decimal? RoomTemp { get; set; }
        public int OfflineCount { get; set; }
        public string PowerRealResult { get; set; }
        public int? ServiceId { get; set; }
        public string ExtraData { get; set; }
        public byte? OldState { get; set; }
        public decimal? WaterTempIn { get; set; }
        public decimal? WaterTempOut { get; set; }
        public byte? WorkType { get; set; }
        public string HostCompInfo { get; set; }
        public string FanStat { get; set; }
        public string ValveStat { get; set; }

        public CommDeviceEx Device { get; set; }
    }
}
