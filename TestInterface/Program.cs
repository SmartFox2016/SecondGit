﻿using CHJSZX.Worker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TestInterface.Tools;
using static TestInterface.Tools.Operate;


namespace TestInterface
{
    //time：2018-06-01
    public class AddTestable : ITestable
    {
        public async Task<int> ExecuteAsyn(int x, int y)
        {
            int result= x + y;
            Console.WriteLine($"调用一个加法运算器，其值为{result}");
            return result;
        }
    }
    public  class MultiTestable : ITestable
    {
        public async Task<int> ExecuteAsyn(int x, int y)
        {
            int result = x * y;
            Console.WriteLine($"调用一个乘法运算器，其值为{result}");
            return result;
        }
    }
    class DBOperate
    {
        public async Task<int?> Execute(ITestable testable)
        {

            return await testable.ExecuteAsyn(3,4);
        }
    }

    public class QGDW3761BasedServer : DotNetty
    {
        protected override void InitializationAction(int channel)
        {
            Console.WriteLine("我实现了抽象方法InitialzationAction!!");
        }
        public void OnStart()
        {
            Console.WriteLine("OnStart方法被触发");
        }
    }

    class Program
    {
        public DateTime TimeStamp { get; set; } = DateTime.Now;
        static void Main(string[] args)
        {
            List<int> list1 = new List<int>();
            int m = 2;
            for (int i = 1;i < 3;i++)
            {
                list1.Add(i);
                if (m == 2) break;
            }
            Program program = new Program();
            program.TimeStamp=new DateTime();
            Console.WriteLine(program.TimeStamp);
            string server = "data source = 123.56.160.179,2478; initial catalog = SmartPower2_Comm_Dev3; " +
                "user id = smartpowerdev5; password = smartpowerdev5179; asynchronous processing = True; " +
                "multipleactiveresultsets = True; application name = CH.Smart.Comm";
            Console.WriteLine($"index={server.IndexOf('=')}");
            //if (server.IndexOf('=='))
            //{

            //}
            //调节线程优先级，--->调高线程优先级
            //Thread.CurrentThread.Priority = ThreadPriority.Highest;

            List<DataFault_Log> dataFault_Logs = new List<DataFault_Log>();
            DataFault_Log fault_Log = new DataFault_Log
            {
                Time = DateTime.Now,
                Tag = "你好"
            };
            dataFault_Logs.Add(fault_Log);
            //此处的Any也是Linq语句
            if (dataFault_Logs.Any(d=>string.Equals("你好",d.Tag)))
            {
                Console.WriteLine("List长度为："+dataFault_Logs.Count);
            }


            List<int> list = new List<int> { 1,2,3,4,5,6};
            var result1 = list.Where(a => {
                return a > 3;
            }).ToList();
            var result2 = list.Where(a => {
                return a > 3;
            }).Sum();
            DeviceManager dm = new DeviceManager();
            //dm.id2Dev[88] = 8666;
            //dm.id2Dev[77] = 7778;
            dm.id2Dev.TryAdd(111,1118);
            
            //int r;
            //dm.id2Dev.TryGetValue(111,out r);///依据key找到value 
            //Console.WriteLine("--- "+r);
            dm.id2Dev[222] = 2228;
            dm.id2Dev[333] = 3338;
            //var device0 = dm.AllDevices.Where(p => //111
            //    1 == 1
            //  ).FirstOrDefault();
            //这就是传说的Linq语句 https://www.cnblogs.com/liulun/archive/2013/02/26/2909985.html  （内容较多，往下拉，方可找到linq）
            var device1 = dm.AllDevices.Where(p => //111
                1 == 1
              ).OrderByDescending(p=>true).ToList();
            var device2 = dm.AllDevices.Where(p =>//222  其中111和222的写法，具有相同的结果
            {
                return 1 == 2;
            }).FirstOrDefault();
            Console.WriteLine(device1);
            Console.WriteLine(device2);
            dm.sn2Dev.TryAdd("1",1);
            dm.sn2Dev["2"]= 2;
            //**********************
            dm.knownFrames=dm.GetAllFrameInfo().ToDictionary(s => s.FrameId);//333
            //dm.knownFrames = dm.GetAllFrameInfo().ToDictionary(s =>  //*333 此处代码与333功能完全一致
            //{
            //    return s.FrameId;
            //});

            Console.WriteLine($"共有{dm.knownFrames.Count} frames are loaded.");
#if DEBUG   //只有在DEBUG模式下在运行，（有Release和Debug两种编译环境）
            DeviceFrame DFrame;
            foreach (var item in dm.knownFrames)
            {
                dm.knownFrames.TryGetValue(item.Key, out DFrame);
                Console.Write($"ID={DFrame.FrameId} Name={DFrame.DeviceName},");

            }                                                                //444 备注：333-->444的代码为了测试 Dictionary的用法
#endif
            DeviceFrame DFrame2;
            if (!dm.knownFrames.TryGetValue(22, out DFrame2))
            {
                Console.WriteLine("未找到");
            }
            
            Operate op = new Operate();
            op.Add(3,5);
#region SnStrConvertDecimal
            Console.WriteLine( "SnStr："+op.SnStrConvertDecimal("1234"));//要逐步明白很多问题
            Console.WriteLine("SnStr：" + op.SnStrConvertDecimal("0186a100"));
            Console.WriteLine("SnStr：" + Int32.Parse("1234"));
            Console.WriteLine("SnStr："+Convert.ToInt32("34", 16));
            Console.WriteLine("SnStr：" + Convert.ToInt32("11", 2));
            Console.WriteLine("SnStr：" + Convert.ToInt32("34", 8));
            Console.WriteLine("SnStr：" + Convert.ToInt32("34", 10));//
#endregion
            AddTestable addTestable =new AddTestable();
            MultiTestable multiTestable = new MultiTestable();
            DBOperate dBOperate = new DBOperate();
            dBOperate.Execute(addTestable);
            dBOperate.Execute(multiTestable);
            Console.ReadKey();
        }
    }
}
