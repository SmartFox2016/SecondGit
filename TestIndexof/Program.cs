using System;
using System.Threading;

namespace TestIndexof
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Start...");
                while (true)
                {
                    Console.WriteLine($"One,{DateTime.Now}");
                    Thread.Sleep(1000*2);
                }
            }
            finally 
            {
                Console.WriteLine($"Two,{DateTime.Now}");
            }
            string dbDevPath = "/416/431";
            int index = 4;
            if (index < 0)
            {
                //-1计算最后一个
                int st = dbDevPath.Length - 1;
                int et;

                do
                {
                    et = st - 1;
                    if (et < 0)
                        //return (-1, -1);
                        Console.WriteLine("(-1, -1)");
                    st = dbDevPath.LastIndexOf('/', et);
                    if (st == -1)
                        //return (-1, -1);
                        Console.WriteLine("(-1, -1)");
                    index++;
                } while (index < 0);
                //return (st + 1, et + 1);
                Console.WriteLine($"({st+1},{et+1})");
            }
            else
            {
                //0计算第一个
                int st;
                int et = 0;

                do
                {
                    st = et + 1;
                    if (st >= dbDevPath.Length)
                        //return (-1, -1);
                        Console.WriteLine("(-1, -1)");
                    et = dbDevPath.IndexOf('/', st);
                    if (et == -1)
                        //return (-1, -1);
                        Console.WriteLine("(-1, -1)");
                    index--;
                } while (index >= 0);
                //return (st, et);
                Console.WriteLine($"({st},{et})");
            }
            Console.ReadKey();
        }
    }
}
