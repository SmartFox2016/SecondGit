using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestJson2
{
    class UtilsTool
    {
        public FanState1 fs1 { get; set; }
    }
    public class FanState1
    {
        public int boardNo { get; set; }
        public string fanHighState1 { get; set; }
    }
    public class FanState2
    {
        public int boardTemp { get; set; }
        public string fanHighState2 { get; set; }
    }

    public class FanState
    {
        public int boardTemp { get; set; }
        public string fanHighState2 { get; set; }
        public int boardNo { get; set; }
        public string fanHighState1 { get; set; }
    }
    public class DataCTEDataCompressor
    {

        public int 压缩机序号 { get; set; }
        public decimal? 翅片温度 { get; set; }
        public decimal? 经济器进口温度 { get; set; }
        public decimal? 经济器出口温度 { get; set; }
        public decimal? 蒸发温度 { get; set; }
        public decimal? 吸气温度 { get; set; }
        public decimal? 排气温度 { get; set; }
    }

}
