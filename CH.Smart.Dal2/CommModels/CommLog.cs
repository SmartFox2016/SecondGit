using System;
using System.Collections.Generic;

namespace CH.Smart.Dal2.CommModels
{
    public partial class CommLog
    {
        public int Id { get; set; }
        public string Tag { get; set; }
        public byte Level { get; set; }
        public string Msg { get; set; }
        public DateTime Time { get; set; }
        public int? SrvId { get; set; }
        public int? GatewayId { get; set; }
        public int? DeviceId { get; set; }
        public string Operator { get; set; }
        public string EndPoint { get; set; }
        public string Path { get; set; }
        public byte? IsEnd { get; set; }
        public DateTime? EndTime { get; set; }
        public string Tag2 { get; set; }

        public CommDeviceEx Device { get; set; }
        public CommService Srv { get; set; }
    }
}
