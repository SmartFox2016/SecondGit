using System;
using System.Collections.Generic;

namespace CH.Smart.Dal2.CommModels
{
    public partial class CommDataExReal
    {
        public int DeviceId { get; set; }
        public string DataKey { get; set; }
        public DateTime DataTime { get; set; }
        public string DataValue { get; set; }

        public CommDeviceEx Device { get; set; }
    }
}
