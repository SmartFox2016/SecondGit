using CHJSZX.Worker;
using System;
using System.Linq;
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
    public abstract class MultiTestable : ITestable
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
    class Program
    {
        static void Main(string[] args)
        {

            DeviceManager dm = new DeviceManager();
            //dm.id2Dev[88] = 8666;
            //dm.id2Dev[77] = 7778;
            dm.id2Dev.TryAdd(111,2222);
            var device = dm.AllDevices.Where(p => //111
                1 == 1
              ).FirstOrDefault();
            var device2 = dm.AllDevices.Where(p =>//222  其中111和222的写法，具有相同的结果
            {
                return 1 == 2;
            }).FirstOrDefault();
            Console.WriteLine(device);
            Console.WriteLine(device2);
            dm.sn2Dev.TryAdd("1",1);
            dm.sn2Dev["2"]= 2;
            Operate op = new Operate();
            op.Add(3,5);
            Console.WriteLine( "SnStr："+op.SnStrConvertDecimal("1234"));
            Console.WriteLine("SnStr：" + op.SnStrConvertDecimal("0186a100"));
            Console.WriteLine("SnStr：" + Int32.Parse("1234"));
            Console.WriteLine("SnStr："+Convert.ToInt32("34", 16));
            Console.WriteLine("SnStr：" + Convert.ToInt32("11", 2));
            Console.WriteLine("SnStr：" + Convert.ToInt32("34", 8));
            Console.WriteLine("SnStr：" + Convert.ToInt32("34", 10));//

            AddTestable addTestable =new AddTestable();
            DBOperate dBOperate = new DBOperate();
            dBOperate.Execute(addTestable);
            Console.ReadKey();
        }
    }
}
