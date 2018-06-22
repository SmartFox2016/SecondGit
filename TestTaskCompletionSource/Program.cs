using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace TestTaskCompletionSource
{
    /*
     * time:2018-05-24
     */
    class TCS
    {
        static void Main(string[] args)
        {
            TaskCompletionSource<int> tcs1 = new TaskCompletionSource<int>();
            Task<int> t1 = tcs1.Task;
            Console.WriteLine("开始时间："+DateTime.Now );
            // Start a background task that will complete tcs1.Task
            Task.Factory.StartNew(() =>
            {
                Thread.Sleep(1000);
                tcs1.SetResult(15);
                tcs1.TrySetResult(16);

            });

            // The attempt to get the result of t1 blocks the current thread until the completion source gets signaled.
            // It should be a wait of ~1000 ms.
            Stopwatch sw = Stopwatch.StartNew();
            int result = t1.Result;
            //
            var result2 = tcs1.Task.Result;
            sw.Stop();  

            Console.WriteLine("(ElapsedTime={0}): t1.Result={1} (expected 15),tcs1.Task={2}  {3}", sw.ElapsedMilliseconds, result, result2, DateTime.Now);

            // ------------------------------------------------------------------

            // Alternatively, an exception can be manually set on a TaskCompletionSource.Task
            TaskCompletionSource<int> tcs2 = new TaskCompletionSource<int>();
            Task<int> t2 = tcs2.Task;

            // Start a background Task that will complete tcs2.Task with an exception
            Task.Factory.StartNew(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("tcs2 started {0}",DateTime.Now);
                tcs2.SetException(new InvalidOperationException("SIMULATED EXCEPTION,{0}"));
            });

            // The attempt to get the result of t2 blocks the current thread until the completion source gets signaled with either a result or an exception.
            // In either case it should be a wait of ~1000 ms.
            sw = Stopwatch.StartNew();
            try
            {
                result = t2.Result;

                Console.WriteLine("t2.Result succeeded. THIS WAS NOT EXPECTED. {0}", DateTime.Now);
            }
            catch (AggregateException e)
            {
                Console.Write("(ElapsedTime={0}): ", sw.ElapsedMilliseconds);
                Console.WriteLine("The following exceptions have been thrown by t2.Result: (THIS WAS EXPECTED) {0}", DateTime.Now);
                for (int j = 0; j < e.InnerExceptions.Count; j++)
                {
                    Console.WriteLine("\n-------------------------------------------------\n{0}", e.InnerExceptions[j].ToString());
                }
            }
            Console.ReadKey();
        }
    }
}
