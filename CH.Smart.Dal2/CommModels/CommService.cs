using System;
using System.Collections.Generic;

namespace CH.Smart.Dal2.CommModels
{
    public partial class CommService
    {
        public CommService()
        {
            CommLog = new HashSet<CommLog>();
        }

        public int ServiceId { get; set; }
        public string Host { get; set; }
        public string DataPort { get; set; }
        public string Desc { get; set; }
        public string CtlPort { get; set; }
        public bool IsMaster { get; set; }
        public byte ServiceState { get; set; }
        public string ServiceGroup { get; set; }
        public string DbgPort { get; set; }
        public string CtlPortV2 { get; set; }

        public ICollection<CommLog> CommLog { get; set; }
    }
}
