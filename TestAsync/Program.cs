using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestAsync
{
    /// <summary>
    /// 异步编程的三种模式
    /// 1.基于任务的异步模式TAP
    /// 2.基于事件**********EAP
    /// 3.异步编程模型APM （要求BeginXxx和EndXxx两个方法来分别表示异步操作的开始和完成）
    ///三种模式的对比： https://www.cnblogs.com/zhili/archive/2013/05/13/TAP.html
    ///备注：Task和async/await的例子来自于 https://blog.csdn.net/coderk2014/article/details/81012004
    ///
    /// 
    /// </summary>
    class Program
    {
        public static void TaskAdd(int data)
        {
            Console.WriteLine($"计算结果为{data+5}，Task开启的线程ID为{Thread.CurrentThread.ManagedThreadId}");
        }
        public static string TaskRead( )
        {
            return "Task开启的线程ID为" + Thread.CurrentThread.ManagedThreadId;
        }
        //有返回值的Task
        public static Task<string> Read2(string str)
        {
            //return "读取的结果为" + str + ",Task开启的线程ID为" + Thread.CurrentThread.ManagedThreadId;
            var x = Task.Run(()=>
            {
                return "读取的结果为" + str + ",Task开启的线程ID为" + Thread.CurrentThread.ManagedThreadId;
            });
            
            return x;
        }
        //无返回值的Task 
        public static void Read3(string str)
        {

        }

        public static async Task<string> AsyncFunc()
        {
            var task = Task.Run(()=>
            {
                Console.WriteLine($"await/async的线程{Thread.CurrentThread.ManagedThreadId}");
                return "这是结果";
            });
            var result = await Read2("Flying");
            Console.WriteLine("! "+result);
            return task.Result; 
        }

        static void Main(string[] args)
        {
            //通过Task实现异步编程
            int m = 1;
            if (m==0)
            {
                Console.WriteLine($"主线程{Thread.CurrentThread.ManagedThreadId}");
                Task task = new Task(()=>TaskAdd(5));
                task.Start();

                var task2 = Task.Run<string>(()=> {
                    return TaskRead();
                });
                Console.WriteLine($"{task2.Result}，Status={task2.Status},IsCompleted={task2.IsCompleted}");
            }
            //通过await/async实现异步编程-->基于任务的异步模式TAP
            if (m==1)
            {
                Console.WriteLine($"主线程{Thread.CurrentThread.ManagedThreadId}");
                Console.WriteLine(AsyncFunc().Result);
            }
 

            Console.ReadKey();
        }
    }
}
