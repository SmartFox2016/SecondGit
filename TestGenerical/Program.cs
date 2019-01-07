using System;

namespace TestGenerical
{
    class Program
    {
        bool? isLocal{ get; set; }
        static void Main(string[] args)
        {
            Program pr = new Program();
            pr.isLocal = null;
            Console.WriteLine("{0},{1}",Math.Sqrt(2)/2, Math.Cos(Math.PI/4));
            Console.ReadKey();
        }
    }
}
