using System;
using System.Threading.Tasks;
using DotNetty.Common.Concurrency;
using DotNetty.Transport.Channels;
using FluentScheduler;

namespace TestSchedule
{
    //定时器 该功能详见https://jingyan.baidu.com/article/455a99506d4f6fa1662778cd.html
    internal class PowerMonitor : Registry
    {
        public PowerMonitor()
        {
            DateTime now = DateTime.Now;
            int align = (900 - (now.Minute % 15) * 60 - now.Second) % 900;
            //在align时间后开始每隔1s进行调用方法OnTime
            Schedule((Action)OnTime).WithName("PowerMonitor")
                .ToRunEvery(1).Seconds().DelayFor(1).Seconds();

        }
        int i = 0;
        public void OnTime()
        {

            Console.WriteLine($"{DateTime.Now}-->第{++i}次运行");
        }
        public Action<string> OnTime2 = (str) =>
             {
                 Console.WriteLine(str);
             };
    }
    class Program
    {
        static void Main(string[] args)
        {
            PowerMonitor pm = new PowerMonitor();
            Console.WriteLine("开始运行:"+ DateTime.Now);
            JobManager.Initialize(new PowerMonitor());//开启任务调用 次
            Console.ReadKey();
        }

        public static void Method()
        {
            object obj=new object();
            //IScheduledTask repushTsk = IEventLoop.Schedule(_pushNext,TimeSpan.FromSeconds(2));
            //IScheduledTask task = IEventLoop.Schedule(_pushNext, obj, obj, TimeSpan.FromSeconds(2));
        }
        private static readonly Action<object, object> _pushNext = (ctxt,uu) =>
          {
              Console.WriteLine("ceshi");
          };
    }
}
