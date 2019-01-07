using System;
using System.Collections.Generic;

namespace CH.Smart.Dal2.CommModels
{
    public partial class CommDeviceEx
    {
        public CommDeviceEx()
        {
            CommDataEx = new HashSet<CommDataEx>();
            CommDataExReal = new HashSet<CommDataExReal>();
            CommLog = new HashSet<CommLog>();
        }

        public int DeviceId { get; set; }
        public string Path { get; set; }
        public string DeviceName { get; set; }
        public byte Level { get; set; }
        public int FrameId { get; set; }
        public int? DeviceRawIdx { get; set; }
        public string DeviceRawSn { get; set; }
        public byte Status { get; set; }
        public string ExtraConfig { get; set; }
        public int? TrackingOldId { get; set; }
        public byte? TrackingOldType { get; set; }
        public string DeviceRawSn2 { get; set; }
        public bool IsDirty { get; set; }
        public string Note { get; set; }
        public byte? DeviceType { get; set; }

        public CommFrame Frame { get; set; }
        public CommDataStat CommDataStat { get; set; }
        public ICollection<CommDataEx> CommDataEx { get; set; }
        public ICollection<CommDataExReal> CommDataExReal { get; set; }
        public ICollection<CommLog> CommLog { get; set; }
    }
}
