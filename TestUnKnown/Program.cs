using System;
using System.Threading;

namespace TestUnKnown
{
    class Program
    {
        //decription:延时调用
        //time:2018-06-08
        static void Main(string[] args)
        {
            var repushLimit = DateTime.Now - TimeSpan.FromSeconds(10);

            var timeOut = new CancellationTokenSource(TimeSpan.FromSeconds(02));
            var timeOutToken = timeOut.Token;
            Console.WriteLine("1,{0}",DateTime.Now);
            timeOutToken.Register(  //当timeOut被执行是调用一个委托
                () => {
                    Console.WriteLine("Hello World! {0}",DateTime.Now);
                }

            );
            Console.WriteLine("2,{0}", DateTime.Now);
            Console.WriteLine("repushLimit=" + repushLimit);
            Console.ReadKey();
        }
    }
}
