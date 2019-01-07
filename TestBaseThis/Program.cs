using System;

namespace TestBaseThis
{
    /*
     * Description:this和base的用法 time：2018-05-10
     * https://www.cnblogs.com/AndyChen2015/p/7927575.html
     */
    public class MyBaseClass
    {
        public MyBaseClass()
        {
            Console.Write("调用父类无参数的构造函数");
        }

        public MyBaseClass(int i)
        {
            Console.Write("调用父类一个参数的构造函数");
        }
        public MyBaseClass(int i, int j)
        {
            Console.Write("  调用父类2个参数的构造函数 ");
        }
    }

    public class MyDerivedClass : MyBaseClass
    {
        public int age;
        public static int age2;//只要类里存在静态变量,那么静态变量总是最先初始化的。

        //静态构造函数只执行一次 好好理解下
        static MyDerivedClass() //既然要初始化静态变量，就要调用静态的构造函数。
        {
            age2 = 100;
            Console.Write(age2);

        }


        public MyDerivedClass()
            : this(5)//调用当前实例有参数的构造函数。如果只调用这个构造函数，那还需要调用一次基类没有参的构造函数！！！
        {

            age = 101;
            Console.Write(age);
        }


        public MyDerivedClass(int i) : base(i)//调用基类有参数的构造函数
        {
            age = 102;
            Console.Write(age);
        }

        public MyDerivedClass(int i, int j) //如果没有出现base，则会调用父类无参数构造器（如果有的话）
        {
            Console.Write("  两个变量的参数 ");
        }
    }

    public class SimpleDbExecutable
    {
        private readonly Func<string> _sqlFact;

        public SimpleDbExecutable(Func<string> sql)
        {
            
            this._sqlFact = sql;  //也就是说，比如，求出3年的首尾增长率R为30%，则3r+3r² 略小于30%。同时，r越小，误差也越小
            Console.WriteLine($"调用一个Func<string>构造器,sql={_sqlFact}");
        }

        public SimpleDbExecutable(string sql)
            : //this(() => sql)
            this(() => {Console.WriteLine(); return "Hello2"; })
        {
            Console.WriteLine($"调用一个string构造器,sql={sql}");
        }

    }
    

    class Program
    {
        static void Main(string[] args)
        {
            //这个例子说明继承的重要性，以及代码运行流程
            ProtocolHandler ph = new ProtocolHandler();
            ph.OnNewOnlineUnsafe();



            SimpleDbExecutable sd = new SimpleDbExecutable("Hello");
            Console.WriteLine("----MyDerivedClass()---");
            MyDerivedClass myder = new MyDerivedClass(); //100调用父类一个参数的构造函数102/101/   
            Console.WriteLine("----MyDerivedClass(5)---");
            MyDerivedClass myder2 = new MyDerivedClass(5);
            Console.WriteLine("----MyDerivedClass(5,6)---");
            MyDerivedClass myder3 = new MyDerivedClass(5, 6);
            Console.ReadKey();

        }
    }
}
