using Microsoft.Extensions.DependencyInjection;//依赖注入
using System;
using System.Threading;
using TestServiceCollection.Tools;

/// <summary>
/// time:2018-7-12
/// description:依赖注入的应用，通过Microsoft.Extensions.DependencyInjection获取接口，抽象类等不能实例化的类型（这只是目前短浅的认识）
/// 详见： http://www.cnblogs.com/ants/p/7130293.html#autoid-7-1-0
/// 好多东西都是慢慢去理解的，但前提要去看；依赖注入，可以往ServiceCollection中添加各种服务，比如对象、接口、基本类型的值等等。。。
/// </summary>
namespace TestServiceCollection
{
    public class Dog : Animal
    {
        public void OnStart()
        {
            Console.WriteLine("OnStart方法被触发");
        }
    }

    public class QGDW3761Service : DotNetty
    {
        protected override void InitializationAction(int channel)
        {
            Console.WriteLine($"shixianle,chnnel={channel}");
            
        }
        
    }

    public class QGDW3761Service2 : DotNetty
    {
        protected override void InitializationAction(int channel)
        {
            Console.WriteLine($"实现了DotNetty,chnnel={channel}");
        }
    }
    class Program
    {
        protected readonly AppConfig config;
        public Program(IServiceProvider scope)
        {
            this.config = scope.GetRequiredService<AppConfig>();
        }
        static void Main(string[] args)
        {
            AppConfig ac = new AppConfig();
            uint i = 2 & 0x80FF0FFF;
            Console.WriteLine($"i=\r\n{i}");
            //类的继承，接口和抽象（virtual）方法的实现，
            var dog = new Dog();//此处可验证父类方法可被子类继承和调用
            dog.OnStart();

            DotNetty dotNetty1;
            var service = new ServiceCollection();//步骤一
            service.AddSingleton("1");//步骤二 
            service.AddSingleton("2");
            QGDW3761Service qGDW3761 = new QGDW3761Service();
            service.AddSingleton(qGDW3761);
            var provider = service.BuildServiceProvider();//步骤三
            Console.WriteLine(string.Join( ",",provider.GetServices<string>()));//将多个string类型的服务找出来
            Console.WriteLine(provider.GetRequiredService<string>());//找出一个string类型的服务   
            

            foreach (var item in provider.GetServices<string>())
            {
                Console.Write(item+" ,");
            }
            //Console.WriteLine(provider.GetService<Program>());
            //Console.WriteLine(provider.GetRequiredService<Program>());
            DotNetty dotNetty = provider.GetRequiredService<QGDW3761Service>();//步骤四 -->获取抽象类的服务实例
            dotNetty.Metod();
            dotNetty.StartAsync();
            Console.ReadKey();
        }
    }
}
