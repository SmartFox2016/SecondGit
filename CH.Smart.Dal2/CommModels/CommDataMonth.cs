using System;
using System.Collections.Generic;

namespace CH.Smart.Dal2.CommModels
{
    public partial class CommDataMonth
    {
        public int DeviceId { get; set; }
        public DateTime StartTime { get; set; }
        public decimal? DeltaValue { get; set; }
        public decimal? TotalValue { get; set; }
        public DateTime DataTime { get; set; }
        public DateTime InsertTime { get; set; }
        public bool IsEstimated { get; set; }
        public byte DataLevel { get; set; }
        public DateTime UpdateTime { get; set; }
        public int? DataRawId { get; set; }
    }
}
