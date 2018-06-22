using System;
using System.Text.RegularExpressions;

namespace TestGenericList
{
    
    public class GenericClass
    {
        public void ShowT<T>(T t)
        {
            //定义一个泛型类,适用不同参数下的调用方法  
            Console.WriteLine("ShowT print {0},ShowT Parament Type Is {1}", t, t.GetType());
        }
    }
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("*****************泛型方法调用*********************");
            GenericClass generice = new GenericClass();
            generice.ShowT<int>(11);
            generice.ShowT<DateTime>(DateTime.Now);
            generice.ShowT<People>(new People { Id = 11, Name = "Tom" });

            /*
             * 只是测试下将键盘输入转为数字
             */
            Console.WriteLine("Now put in an number:");
            var CheckNum =Console.ReadLine();
            bool IsDouble = Regex.IsMatch(CheckNum, @"^[+-]?\d*[.]?\d*$");
            if (IsDouble)
            {
                Console.WriteLine("The number is: " + Convert.ToDouble(CheckNum));

            }
            else
            {
                Console.WriteLine("The resule is: " + CheckNum);
            } 
            Console.ReadKey();
        }
    }

    class People
    {
        public int Id { get; internal set; }
        public string Name { get; internal set; }
    }
}
