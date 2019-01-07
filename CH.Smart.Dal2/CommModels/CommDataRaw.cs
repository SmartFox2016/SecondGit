using System;
using System.Collections.Generic;

namespace CH.Smart.Dal2.CommModels
{
    public partial class CommDataRaw
    {
        public int DeviceId { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public decimal? DeltaValue { get; set; }
        public decimal? TotalValue { get; set; }
        public DateTime DataTime { get; set; }
        public DateTime InsertTime { get; set; }
        public decimal? AvgValue { get; set; }
        public byte DataType { get; set; }
        public byte DataLevel { get; set; }
        public int Id { get; set; }
        public DateTime UpdateTime { get; set; }
        public DateTime? StartTimeRaw { get; set; }
        public byte DataFlags { get; set; }
    }
}
