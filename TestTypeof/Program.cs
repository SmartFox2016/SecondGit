using System;
using System.Reflection;
using System.Threading.Tasks;

namespace TestTypeof
{
    public class SwitchInfo: IComparable
    {
        public int DevId { get; set; }
        public bool IsOn { get; set; }

        public int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }
    }
    public class ResultModel<T>
    {
        public string StateDesc { get; set; }
        public T Data { get; set; }
    }
    //用于获取类型的System.Type 对象。typeof 表达式采用以下形式：
    //System.Type type = typeof(int);
    class Program
    {
        public int sampleMember;
        public void SampleMethod()
        { }
        public void SampleMethod22()
        { }
        public static void GetT()
        {
            int result;
            for (int m = 1; m < 5; m++)
            {
                switch (m)
                {
                    case 1:
                        {
                            result = m + 1;
                            Console.WriteLine("结果1："+result);
                        }
                        break;
                    case 2:
                        {
                            result = m + 2;
                            Console.WriteLine("结果2：" + result);
                        }
                        break;
                    case 3:
                        {
                            result = m + 3;
                            Console.WriteLine("结果3：" + result);
                        }
                        break;
                    //default:
                    case 4:
                            result = m + 4;
                            Console.WriteLine("结果4：" + result);
                        break;
                }
            }
        }

        public void CtlCTEAsync2()
        //public void CtlCTEAsync2<T>()
        {
            SwitchInfo SI = new SwitchInfo();
            Console.WriteLine("ceshi=");
        }
        static void Main(string[] args)
         {

            Type t = typeof(Program);
            Program p = new Program();
            Program.GetT();
            //p.CtlCTEAsync2();
            var infos1 = t.GetTypeInfo();
            Console.WriteLine(infos1+",,"+t.ToString());
            //MemberInfo[] infos = t.GetMembers(); //打印出成员变量类型
            MethodInfo[] infos = t.GetMethods(); //打印出成员方法类型
            foreach (var item in infos)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine("----------------");

            foreach (var item in infos1.GetProperties())
            {
                Console.WriteLine("11"); 
                Console.WriteLine(item.PropertyType);
            }

            Console.ReadKey();
         }
    }
}
