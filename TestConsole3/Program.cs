using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole3
{
    interface ISubject
    {
        void NotifyObserver(string msg);
        void AddObserver(IObserver observer);
        void RemoveObserver(IObserver observer);
    }

    interface IObserver
    {
        void Notify(string msg);
    }

    class MySubject : ISubject
    {
        //定义一个数组
        ArrayList arrayList = new ArrayList();
        public void AddObserver(IObserver observer)
        {
            if (!arrayList.Contains(observer))
            {
                arrayList.Add(observer);
            }
        }

        public void RemoveObserver(IObserver observer)
        {
            if (arrayList.Contains(observer))
            {
                arrayList.Remove(observer);
            }
        }

        public void NotifyObserver(string msg)
        {
            foreach(IObserver observer in arrayList)
            {
                observer.Notify(msg);
            }
        }

    }

    class MyObserver : IObserver
    {
        public void Notify(string msg)
        {
            Console.WriteLine("receive msg:"+msg);
            Console.WriteLine("receive msg:{0}" , msg);
        }

       
    }
    
    class Program
    {
        //这是一个迭代器
        public static IEnumerable SimpList()
        {
            //yield return "spring";
            //yield return "summer";
            //yield return "autumn";
            //yield return "winter";
            yield return 1;
            yield return 2;
        }


        static void Main(string[] args)
        {
            ISubject subject = new MySubject();
            subject.AddObserver(new MyObserver());
            subject.NotifyObserver("it is a test");
            foreach (int item in SimpList())
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
        }
    }

    
}
