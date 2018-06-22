using System;

namespace TestReconstruct.EncapsulateConditional
{
    /*
     * “封装条件”是指条件关系比较复杂时，代码的可读性会比较差，
     * 所以这时我们应当根据条件表达式是否需要参数将条件表达式提取成可读性更好的属性或者方法，如果条件表达式不需要参数则可以提取成属性，如果条件表达式需要参数则可以提取成方法。
     * time:2018-04-12
     */
    public class RemoteControl
    {
        //属性字段，这个在这里是干嘛的？有点想不明白，慢慢理解喽
        private string[] Functions { get; set; }
        private string Name { get; set; }
        private int CreatedYear { get; set; }

        private bool HasExtraFunctions
        {
            get { return  Name == "RCA" && Functions.Length > 1 && CreatedYear > DateTime.Now.Year - 2; }
        }
        public string PerformCoolFunction(string buttonPressed)
        {
            //Determine if we are controlling some extra function
            // that requires special conditions
            if (HasExtraFunctions)
                return "doSomething";
            return "I am sorry！！";
        }
    }
    class Program
        {
            static void Main(string[] args)
            {

                RemoteControl rc = new RemoteControl();
                //rc.Functions ="","";
                string result=rc.PerformCoolFunction("");

                Console.WriteLine("Hello World!"+result);
                Console.ReadKey();
            }
        }
}
