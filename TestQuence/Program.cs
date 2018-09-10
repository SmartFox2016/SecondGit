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
        public static IEnumerable<string> AllInfo2 { get { return id2Dev.Values; } }//获取Dictionary<key,value>中的值value
        public static IEnumerable<string> AllInfo3 { get { return id2Dev.Values; } }
        

        static void Main(string[] args)
        {
            Queue<int> queue = new Queue<int>(2);
            queue.Enqueue(0);//向队列里添加元素
            queue.Enqueue(1);
            queue.Enqueue(2);
            Console.WriteLine($"Queue的长度：{queue.Count}");
            int i = 0;
            foreach (var item in queue)
            {
                Console.WriteLine($"第{++i}个元素为{item}");//TODO hello
            }
            //queue.Count;
            Console.WriteLine(queue.Dequeue());//Dequeue 出队列且将其删除
            i = 0;
            foreach (var item in queue)
            {
                Console.WriteLine($"第{++i}个元素为{item}");
            }

            Program.id2Dev.TryAdd(1,"Ni hao");
            //var result=Program.AllInfo.Where(g =>
            //true).FirstOrDefault(); //11
            var result = Program.AllInfo.Where(g =>
              {
                  //return g.Equals("Ni hao");
                  return true; //22 11和22写法相同，区别在于{}
              }).FirstOrDefault();
            Console.WriteLine(result);

            Console.WriteLine("--The end!!!--");
            Console.ReadKey();
        }
    }
}
