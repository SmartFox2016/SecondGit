using System;

namespace TestReconstruct
{
    /*
     *description:代码重构中，利用委托来代替不适于类继承的情况
     *Created by flying on 2018-04-10 
     */
    //类可继承类和接口
    public  class Sanitation
    {
        public string WashHand()
        {
            return "I'm ok!!";
        }
    }
    class Program
    {
        private Sanitation san { set; get; }
        public string Id { get => id; set => id = value; }

        private string id ;
        public int Name { get; set; } //prop 然后按tab建
        public Program()
        {
            Sanitation sa = new Sanitation();
        }

        public string WashHand()
        {
            return san.WashHand();
        }

        static void Main(string[] args)
        {
            
            Program pr = new Program();
            string str=pr.WashHand();
            Console.WriteLine("将继承变为委托的结果："+str);
            Console.ReadKey();
        }
    }
}
