using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestOther;
using static TestOther.Program;

namespace TestOther
{
    //time:2018-5-18
    abstract class Factory
    {
        public abstract void Make();
        public void Design()
        {
            Console.WriteLine("中国设计");
        }
    }
    interface IInterface
    {
         int Age();
    }
    class CarFactory : Factory,IInterface
    {
        internal class BusFactory
        {

        }
        public int Age()
        {
            throw new NotImplementedException();
        }

        public override void Make()
        {
            Console.WriteLine("中国智造");
        }
    }
    public class TestReference
    {
        public TestReference()
        {
            Console.WriteLine($"引用对象{nameof(TestReference)}");
        }
        public  void  GetAdd(int x,int y)
        {
            Console.WriteLine($"计算结果为：{x+y}");
        }
        public void GetMultiply(int x, int y,object param=null,string str="ID")
        {
            Console.WriteLine($"计算结果为：{x * y},param={param},str={str}");//江湖豪杰  载淳 载湉 溥仪 溥杰 
        }
    }
    class Program 
    {
        private static byte by1;
        static int method1(int s)
        {
            return s * 2;
        }

        static int method2(int s)
        {
            return s * s;
        }
        static int method3(int s) {
            int result = s * 10;
            Console.WriteLine("method(3)={0},{1}",result,DateTime.Now);
            return result;
            
        }

        static void method4(string str)
        {
            Console.WriteLine("Hello,"+str);
        }
        public static int pring(Func<int, int> method)
        {
            return method(5);
        }
        public static int print(Func<int, int> method,int t)
        {
            return method(t);
        }

        public static void print2(Action<int > method,int t)
        {
            method(t);
        }

        public delegate int MyDelegate(int s);

        static void Main(string[] args)
        {
            TestReference reference = new TestReference();
            reference.GetMultiply(1,2,  //方法一，利用自定义参数调用 
                param:new {Dog="H"},
                str:"Hello");
            reference.GetMultiply(3, 2);//方法二，利用默认参数调用
            //---利用delegate
            MyDelegate my= new MyDelegate(method3);//把method3方法名传递给委托 
            my(3);
            //my(3)和my1(3)的用法是一致的
            MyDelegate my1 = (int s) =>
            {
                int result = s * 10;
                Console.WriteLine("my(1)="+result);
                return result;
            };
            my1(3);

            //---利用Func进行委托
            Func<int, int> MyFunc;
            MyFunc = new Func<int, int>(method3);
            //MyFunc(3);//11
            MyFunc.Invoke(3);//22,此处代码等于11处代码。调用委托
            MyFunc = method3;//33,此处代码等于11和22处代码，Func<>的匿名委托  
            var result2=print(p => 
            {
                return p * 5;
            },10);
            Console.WriteLine($"result2={result2}");
            //利用Action进行委托调用
            Action<string> A1;
            A1 = new Action<string>(method4); 
            A1("Li Lei");
            string str2 = "Jack";
            A1.Invoke(str2);

            

            int? a = 1; //可空类型修饰符
            var dev = a?.ToString();
            String str = "Hello";
            Console.WriteLine(str??"我是一个空内容");//空合并运算符
            Console.WriteLine(dev);

            LinkedList<Byte> lb2 = new LinkedList<byte>();
            lb2.AddFirst(4);
            lb2.AddFirst(5);
            lb2.AddFirst(6);
            Console.WriteLine("-----LinkedList-----");
            foreach (var item in lb2)
            {
                Console.Write(item+" ");
            }
            Console.WriteLine();
            Queue<Byte> queue = new Queue<Byte>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            Console.WriteLine("-----Queue-----");
            //Console.WriteLine(queue.Dequeue()); 
            foreach (var item in queue)
            {
                Console.Write(item+" ");
            }
            Console.WriteLine( "--Func--"+print(method1,5));
            Console.WriteLine("--Func--" + print(p=> {
                return  p * 11;
            }, 5));
            Console.WriteLine("--Func--" + print(p => 
                 p * 11
            , 5));
            print2(p => {
               Console.WriteLine(p * 10000);
           },5);
            Console.WriteLine("打印纸：" + pring(new Func<int, int>(method1)));//10
            Console.WriteLine("打印纸：" + pring(new Func<int, int>(method2)));//25
            Console.WriteLine("打印纸：" + pring((i) => {//50 把委托调用的方法用（等同于method3()）拉姆达表达式来表示，
                return 10 * i;                           //它等同于下面的调用
            }));
            Console.WriteLine("打印纸：" + pring(new Func<int, int>(method3)));//25


            string batteryDATA4 = "68:01:01:01:bc";
            string testDATA4 = "68:01:01:00:01:01:9F:F4";
            string readDATA4 = "01 04 20 00 F1 00 EF 00 EF";// 这是多功能电表的数据
            //string[] batteryMSGstr = testDATA4.Split(new char[1] { ':' });// 这是电网的数据
            string[] batteryMSGstr = readDATA4.Split(" ");
            //string[] batteryMSGstr = batteryMSG.Split(':');
            Console.WriteLine(batteryMSGstr.Length);
            byte[] returnBytes = new byte[batteryMSGstr.Length];
            for (int i = 0; i < batteryMSGstr.Length; i++)
            {
                returnBytes[i] = Convert.ToByte(batteryMSGstr[i], 16);
                Console.Write(returnBytes[i]+" ");
            }
            Console.WriteLine(returnBytes);
            Console.ReadKey();
        }
        private static void Method(byte[] msg)
        {
            foreach (var item in msg)
            {
                Console.WriteLine(item);
            }
        }
        private static void Method2(List<Byte> msg)
        {
            Console.WriteLine("-----Method2----");
            foreach (var item in msg)
            {
                Console.Write(item+" ");
            }
            Console.WriteLine();
        }
        
    }
}
