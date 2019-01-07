using System;
using System.Threading.Tasks;

namespace TestAttribute
{
    public class ActionResponseAttribute : SpecialActionAttribute
    {
        public ActionResponseAttribute()
        {
            base.IsPRM = false;
        }
    }
    class Program
    {
        [ActionGroupInfo(0x0C, 26, typeof(string), typeof(int), "请求1类数据->当前空调节点实时用电数据")]
        public static string Name;

        public static async Task Method(string[] devIds)
        {
            if (devIds.Length>1)
            {
                Console.WriteLine("我是if语句");
                return;//return语句终止它所在的方法的执行，并将控制权返回给调用方法
            }
            
            for (int i = 0; i < devIds.Length; i++)
            {
                Console.WriteLine($"for={i}");
            }
        }
        static void Main(string[] args)
        {
            Program.Name="FC";
            ActionResponseAttribute AR = new ActionResponseAttribute();
            AR.AFN = 0x10;
            AR.F = 3;
            string[] str = new string[2] { "1","2"};
            Program.Method(str);
            UntilTool.Method("1FFFFF");
            Console.ReadKey();
        }
    }
}
