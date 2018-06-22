using System;

namespace TestReconstruct.ExtrInterface
{
    /*
     * Description:提取接口 strategy
     * Created by Flying on 2018.4.11
     */

    public interface IRegistration
    {
        void Creat();
        decimal Total { get; }
    }

    public class ClassRegistration : IRegistration, IClassRegistration
    {
        public void Creat()
        {
            Console.WriteLine("Hello World!"+DateTime.Now);
        }

        public void Transfer()
        {
            Console.WriteLine("Hello World!");
        }

        public decimal Total { get; private set; }
    }

    class RegistrationProcessor
    {
        public decimal Process(IRegistration ir)
        {
            ir.Creat();
            return ir.Total;
        }
    }

    public enum Date
    {
        Day,night,Moring,moon,Aftermoon
    }

    class Program
    {
        static void Main(string[] args)
        {
            RegistrationProcessor rp = new RegistrationProcessor();
            //IRegistration ir = new IRegistration();
            Console.WriteLine("Hello World!");
        }
    }
}
