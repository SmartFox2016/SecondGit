using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace TestQuence
{
    class Program
    {
        static ConcurrentDictionary<int, string> id2Dev = new ConcurrentDictionary<int, string>();
        
        public static IEnumerable<string> AllInfo { get { return id2Dev.Values; } }

        static void Main(string[] args)
        {
            Queue<int> queue = new Queue<int>(2);
            queue.Enqueue(0);
            queue.Enqueue(1);
            queue.Enqueue(2);
            int i = 0;
            foreach (var item in queue)
            {
                Console.WriteLine($"第{++i}个元素为{item}");
            }
            //queue.Count;
            Console.WriteLine(queue.Dequeue());
            i = 0;
            foreach (var item in queue)
            {
                Console.WriteLine($"第{++i}个元素为{item}");
            }
            var result=Program.AllInfo.Where(g =>
            false).FirstOrDefault();
            Console.WriteLine(result);
            Console.WriteLine("--The end!!!--");
            Console.ReadKey();
        }
    }
}
