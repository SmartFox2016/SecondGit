using CHJSZX.Worker;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace TestInterface.Tools
{
    class Operate
    {
        public void Add(int x,int y)
        {
            Console.WriteLine($"The result is {x+y},@{DateTimeKind.Local}");
        }
        //将字符串转为十进制数 https://zhidao.baidu.com/question/62290479.html  
        public decimal SnStrConvertDecimal(string data)
        {
            decimal returnData = 0;

            bool isOdd = (data.Length % 2) == 1 ? true : false;
            if (isOdd)
            {
                int count = data.Length / 2 + 1;
                for (int i = 0; i < count; i++)
                {
                    string factorStr;
                    if (i == (count - 1)) factorStr = data.Substring(i * 2, 1);
                    else factorStr = data.Substring(i * 2, 2);
                    returnData = returnData + Convert.ToInt32(factorStr, 16) * ((int)Math.Pow(16, i)); ;
                }
            }
            else
            {
                int count = data.Length / 2;
                for (int i = 0; i < count; i++)
                {
                    string factorStr = data.Substring(i * 2, 2);
                    returnData = returnData + Convert.ToInt32(factorStr, 16) * ((int)Math.Pow(16, i)); ;
                }
            }

            return returnData;
        }
        public void  GetFDatas(byte dt11,byte dt22)
        {
            short result;
            var dt1 = dt11;
            var dt2 = dt22;
            byte x = dt1, y = 1;
            while (x != 0)
            {
                if ((x & 0x01) != 0)
                {
                    //NOTE: 已经是从小到大的了
                      result=(short)(dt2 * 8 + y);
                }

                x >>= 1;
                ++y;
            }
            Console.WriteLine()
        }

        public class DataFault_Log
        {
            public int ID { get; set; }
            public string Tag { get; set; }
            public int? Level { get; set; }
            public string Tag2 { get; set; }
            public string Msg { get; set; }
            public DateTime Time { get; set; }
            public int? Srv_ID { get; set; }
        }

        public class DeviceManager
        {
            public ConcurrentDictionary<int, int> id2Dev = new ConcurrentDictionary<int, int>();
            public Dictionary<string, int> sn2Dev = new Dictionary<string, int>();
            //NOTE: 此处若不为ConcurrentDictionary则需ToList(), 因为可能动态增减 
            public IEnumerable<int> AllDevices { get { return id2Dev.Values; } }

            public Dictionary<int, DeviceFrame> knownFrames = new Dictionary<int, DeviceFrame>();
            public IEnumerable<DeviceFrame> GetAllFrameInfo()
            {
                return new DeviceFrame[]
                {
                    new DeviceFrame{FrameId=11,DeviceName="多功能仪表" },
                    new DeviceFrame{FrameId=2,DeviceName="集中式低温机" },
                    new DeviceFrame{FrameId=3,DeviceName="煤改电"},
                    new DeviceFrame{FrameId=4,DeviceName="风度仪" },
                };
            }
        }

    }
    //partial相当于把一个类分成两部分，但这两部分的类中的属性、字段和方法可相互用
        public abstract partial class DotNetty
        {
            
            public void StartAsync ()
            {
                this.Age = 100;
                this.InitializationAction(888);
            }
            protected abstract void InitializationAction(int channel);
        }
}
