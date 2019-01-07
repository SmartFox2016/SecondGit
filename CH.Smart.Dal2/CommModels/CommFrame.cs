using System;
using System.Collections.Generic;

namespace CH.Smart.Dal2.CommModels
{
    public partial class CommFrame
    {
        public CommFrame()
        {
            CommDeviceEx = new HashSet<CommDeviceEx>();
        }

        public int FrameId { get; set; }
        public string FrameVendor { get; set; }
        public string FrameRawName { get; set; }
        public string FrameHwVer { get; set; }
        public string FrameSwVer { get; set; }
        public int? DefServiceId { get; set; }
        public string FrameType { get; set; }
        public string ServiceGroup { get; set; }
        public string FrameName { get; set; }
        public string ExtraConfig { get; set; }
        public string Note { get; set; }

        public ICollection<CommDeviceEx> CommDeviceEx { get; set; }
    }
}
