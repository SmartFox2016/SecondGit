using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestJson2
{
    class Program
    {
        public static void Add(object data)
        {
            var result = JsonConvert.SerializeObject(data);
        }

        static void Main(string[] args)
        {
            Add(12.3);
            List<DataCTEDataCompressor> Compressoses = new List<DataCTEDataCompressor>();
            DataCTEDataCompressor 压缩机1温度 = new DataCTEDataCompressor();
            压缩机1温度.压缩机序号 = 1;
            压缩机1温度.吸气温度 = 11;
            DataCTEDataCompressor 压缩机2温度 = new DataCTEDataCompressor();
            压缩机2温度.压缩机序号 = 2;
            压缩机2温度.吸气温度 = 22;
            Compressoses.Add(压缩机1温度);
            Compressoses.Add(压缩机2温度);
            
            UtilsTool utilsTool = new UtilsTool();
            utilsTool.fs1 = new FanState1();
            FanState1 fs2 = new FanState1();
            var a1 = JsonConvert.SerializeObject(Compressoses[0]);
            var a2 = JsonConvert.SerializeObject(Compressoses[1]);
            utilsTool.fs1.fanHighState1 = JsonConvert.SerializeObject(Compressoses[0]);
            var a3 = JsonConvert.SerializeObject(utilsTool.fs1);
           List<FanState1> fanStates1 = new List<FanState1>();
            List<FanState2> fanStates2 = new List<FanState2>();
            utilsTool.fs1 = new FanState1();
            for (int i = 0; i < 2; i++)
            {
                //FanState1 fan = new FanState1();
                
                utilsTool.fs1.boardNo = i;
                utilsTool.fs1.fanHighState1 = "High";
                fanStates1.Add(utilsTool.fs1);
                //var m = JsonConvert.SerializeObject(utilsTool.fs1);
                //Add(utilsTool.fs1.boardNo);

            }
            var a = fanStates1[1];
            for (int i = 0; i < 2; i++)
            {
                FanState2 fan = new FanState2();
                fan.boardTemp = i;
                fan.fanHighState2 = "Low";
                fanStates2.Add(fan);
            }
            for (int i = 0; i < 2; i++)
            {
                FanState fs = new FanState();
                fs.boardNo = fanStates1[i].boardNo;
                fs.fanHighState1 = fanStates1[i].fanHighState1;
                fs.boardTemp = fanStates2[i].boardTemp;
                fs.fanHighState2 = fanStates2[i].fanHighState2;
                var result= JsonConvert.SerializeObject(fs);
            }
            for (int i = 0; i < 3; i++)
            {
                if (i >= 1) break;
                Console.WriteLine(i);
            }
            Console.ReadKey();
        }
    }
}
