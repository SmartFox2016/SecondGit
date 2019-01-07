using System;
using System.Collections.Generic;

namespace CH.Smart.Dal2.CommModels
{
    public partial class CommDataHeatRaw
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
        public decimal? TempIn { get; set; }
        public decimal? TempOut { get; set; }
        public decimal? FlowIn { get; set; }
        public decimal? FlowOut { get; set; }
        public decimal? SpeedIn { get; set; }
        public decimal? SpeedOut { get; set; }
        public decimal? PressureIn { get; set; }
        public decimal? PressureOut { get; set; }
        public decimal? CurrentCooling { get; set; }
        public decimal? CurrentHeatint { get; set; }
        public decimal? HeatingPower { get; set; }
        public DateTime? TotalTime { get; set; }
        public DateTime? RealTime { get; set; }
        public string St1 { get; set; }
        public string St2 { get; set; }
        public decimal? DayHeating { get; set; }
        public decimal? CurrentFlow { get; set; }
        public decimal? TotalFlow { get; set; }
        public byte? HmeterType { get; set; }
    }
}
