using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestConsole13
{
    #region Test
    /// <summary>
    /// 在t1线程中，LockMe调用了lock(this), 也就是Main函数中的c1，这时候在主线程中调用lock(c1)时，
    /// 必须要等待t1中的lock块执行完毕之后才能访问c1，
    /// 即所有c1相关的操作都无法完成，于是我们看到连c1.DoNotLockMe()都没有执行。
    /// </summary>
    class Test
    {
        private bool deadlocked = true;
        //这个方法用到了lock，我们希望lock的代码在同一时刻只能由一个线程访问
        public void LockMe(object o)
        {
            lock (this)
            {
                while (deadlocked)
                {
                    deadlocked = (bool)o;
                    Console.WriteLine(DateTime.Now+"  Foo: I am locked :(");
                    Thread.Sleep(1000);
                }
            }
        }
        //所有线程都可以同时访问的方法
        public void DoNotLockMe()
        {
            Console.WriteLine(DateTime.Now+"  I am not locked :");
        }
    }
    #endregion


    #region Test2
    /// <summary>
    /// 这次我们使用一个私有成员作为锁定变量(locker)，在LockMe中仅仅锁定这个私有locker，而不是整个对象。
    /// 这时候重新运行程序，可以看到虽然t1出现了死锁，
    /// DoNotLockMe()仍然可以由主线程访问；LockMe()依然不能访问，原因是其中锁定的locker还没有被t1释放。
    /// </summary>
    class Test2
    {
        private bool deadlocked = true;
        public  object locker = new object();
        //这个方法用到了lock，我们希望lock的代码在同一时刻只能由一个线程访问
        public void LockMe(object o)
        {
            lock (locker)
            {
                while (deadlocked)
                {
                    deadlocked = (bool)o;
                    Console.WriteLine(DateTime.Now + "  Foo: I am locked :(");
                    Thread.Sleep(1000);
                }
            }
        }
        //所有线程都可以同时访问的方法 
        public void DoNotLockMe()
        {
            Console.WriteLine(DateTime.Now + "  I am not locked :");
        }
    }
    #endregion
    public class Class1
    {
        
        static void Main(string[] args)
        {
            //关于lock多线程同步问题，详见https://www.cnblogs.com/gsk99/p/4964063.html
            //Test2 test = new Test2();
            ////在t1线程中调用LockMe，并将deadlock设为true（将出现死锁）
            //Thread t1 = new Thread(test.LockMe);
            //t1.Start(true);
            //Thread.Sleep(1000);
            ////在主线程中lock test
            //lock (test)
            //{
            //    //调用没有被lock的方法
            //    test.DoNotLockMe();
            //    //调用被lock的方法，并试图将deadlock解除
            //    test.LockMe(false);
            //}

            /*
             * description:测试基于谓词筛选值序列 
             * time:2018-03-26
             */
            var basePath1 = AppDomain.CurrentDomain;
            var basePath2 = AppContext.BaseDirectory;
            var basePath3 = Directory.GetCurrentDirectory();
            Console.WriteLine("Path3:  "+basePath3);

            foreach (var item in Directory.EnumerateFiles(basePath2,"*.txt", SearchOption.AllDirectories))
            {
                Console.WriteLine(item);
                try
                {
                    Console.WriteLine("1");
                    var assembly = Assembly.LoadFile(item);
                    Console.WriteLine("2");
                }
                catch (Exception e)
                {
                    Console.WriteLine("error: "+e.Message);
                }
            }

            List<string> fruits =
                new List<string> {"apple", "passionfruit", "banana", "mango",
                                "orange", "blueberry", "grape", "strawberry"  };
            IEnumerable<string> query = fruits.Where(fruit => fruit.Length > 6);
            foreach (string fruit in query)
            {
                Console.WriteLine(fruit);
                
            }

            /*
             * description:测试异步编程中线程池ThreadPool的用法 
             * time:2018-03-26 pm：17:58
             */
            int i = 0, j = 0;
            ThreadPool.GetMaxThreads(out i,out j);//获取线程最大数量
            Console.WriteLine(i.ToString()+"  "+j.ToString());
            ThreadPool.GetAvailableThreads(out i,out j);//获取当前可用线程数量
            Console.WriteLine(i.ToString() + "  " + j.ToString());
            ThreadPool.QueueUserWorkItem(state => RunWorkerThread());//和下面是一样的
            //ThreadPool.QueueUserWorkItem(new WaitCallback(RunWorkerThread));
            Console.ReadKey();
        }
        static void RunWorkerThread()
        {
            Console.WriteLine("RunWorkerThread开始工作");
            Console.WriteLine("工作者线程启动成功!");
        }
    }   
}
