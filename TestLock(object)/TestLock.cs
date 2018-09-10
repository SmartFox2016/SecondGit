using System;
using System.Threading;

namespace TestLock_object_
{
    /*
     * Description:关于Lock（this）和Lock（object obj）的讲解
     * time：2018-05-16 PM
     */
    class C1
    {
        private bool deadlocked = true;
        private object locker = new object();
        //这个方法用到了lock，我们希望lock的代码在同一时刻只能由一个线程访问
        public void LockMe(object obj)
        {
            lock (locker)//锁定的是私有对象,
            //lock (this)//锁定的是全局对象C1
            {
                while (deadlocked)
                {
                    deadlocked = (bool)obj;
                    Console.WriteLine("{0}---LockMe-- Foo: I am locked :(",DateTime.Now);
                    Thread.Sleep(500);
                }
            }
        }
        //所有线程都可以同时访问的方法
        public void DoNotLockMe()
        {
            Console.WriteLine("{0}---DoNotLockMe---- I am not locked :)", DateTime.Now);
        }
    }

    class TestLock
    {
        private object locker2 = new object();//这是定义了一个object 锁对象，这是要和lock(this)做区别 
        static void Main(string[] args)
        {
            DateTime dt= DateTime.UtcNow + TimeSpan.FromMinutes(10);
            Console.WriteLine($"现在时间：{DateTime.Now},  {DateTime.UtcNow}");
            C1 c1 = new C1();
            TestLock tLock = new TestLock();
           Thread t1 = new Thread(c1.LockMe);
            t1.Start(true);
            Thread.Sleep(1000);
            //在主线程中lock c1
            lock (c1)
            //lock (tLock.locker2)
            {
                //调用没有被lock的方法
                c1.DoNotLockMe();
                //调用被lock的方法，并试图将deadlock解除
                c1.LockMe(false);
            }
            Console.ReadKey( );
        }
    }
}
