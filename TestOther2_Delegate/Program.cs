using System;

namespace TestOther2_Delegate
{
    /*
     * time:2018-5-17 
     */


    class Animal : IAnimal, IEatable
    {
        void IEatable.Eat()
        {
            throw new NotImplementedException();
        }

        void IAnimal.Run()
        {
            throw new NotImplementedException();
        }

        void IWalkable.Walk()
        {
            Console.WriteLine("I can walk quickly");
        }
    }
    class C1
    {
        public int Age;
        private readonly IWalkable _walk;
        public C1(IWalkable walk)
        {
            this._walk = walk;//路灯原则
        }
        //Animal an=new Animal(); 代码还是棒棒哒
        //IAnimal ian = new IAnimal();//接口不能被实例化
        public void Skill(IWalkable w = null)//这是函数的默认参数，即当调用者没传参数时，就用该默认值
        {
            w = w ?? this._walk;
            Console.WriteLine("w=" + w);
            w.Walk();
            //this.Walk.Walk();
        }
    }
    class C2
    {
        public int Age;
        public string Name;
    }
    class C3 : C2
    {

       
       
    }

    class Program
    {
        //public static readonly Action<int> onSuccess;
        public readonly Func<int, int> method;
        public static DateTime date;
        static void Main(string[] args)
        {
            Cat cat = new Cat();
            Object c = cat as Object;//此时c=TestOther2_Delegate.Cat
            //-----------
            //Object o = new Object();
            //Cat c=  o as Cat;//无法将object强制转成Cat，因为Object是所有类的父类，此时c=null，执行c.ToString()会报错System.NullReferenceException
            if (c!=null)
            {
                Console.WriteLine("c="+c.ToString());
            }else
            {
                Console.WriteLine("c=null");
                c.ToString();
            }
            //综合测试接口的继承，接口的实现，以及接口作为函数参数被调用
            Animal animal = new Animal();
            C1 c1 = new C1(animal);
            //c1.Skill();
            c1.Skill(animal);
            //-------------
            //Action的普通用法
            Console.WriteLine(DateTime.Now);
            Action<int> onSuccess;
            onSuccess = new Action<int>(mthod);
            onSuccess?.Invoke(3);

            //Action的进阶用法
            Test<string>(Method, "Hello World!,Flying!!!"); //11传递方法名
            Test<string>(
                (p) => 
                {
                    Console.WriteLine(p);
                }, "Hi");//22，备注：22和11两者是相同的
            Console.ReadKey();

        }
        //
        private static void Test<T>(Action<T> action, T p)
        {
            action(p);
        }
        private static void Method(string s)
        {
            Console.WriteLine(s);
        }


        private static void mthod(int obj)
        {
            Console.WriteLine("Hello World!" + obj);
            //throw new NotImplementedException();
        }
        private static void mthod(Func<string, int> receiver)
        {
            receiver("");
            Console.WriteLine("Hello World!" + receiver);//让天下没有难做的生意
            //throw new NotImplementedException();以前我的生活是工作（奋斗期），以后我的工作是生活（享受期）。
        }
        public void Add(int x,int y) =>Console.WriteLine(x+y) ;//棉花糖写法
    }
}
