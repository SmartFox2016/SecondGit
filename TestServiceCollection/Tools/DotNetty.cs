using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestServiceCollection.Tools
{
    public class Animal
    {
        
    }
    //partial class 把一个类写在不同的地方，但他们可以相互共享属性、字段和方法
    public abstract partial class DotNetty
    {
        int Age;
        public DotNetty()
        {
            Environment.SetEnvironmentVariable("io.netty.allocator.maxOrder", "5");
            //Console.WriteLine("我是DotNetty构造器");
            //Console.WriteLine(this.Metod());
            //this.StartAsync();
        }
        public IServiceProvider Metod()
        {
            Console.WriteLine("运行Metod()");
            ServiceCollection service = new ServiceCollection();
            service.AddSingleton(this);
            var provider = service.BuildServiceProvider();
            Console.WriteLine(provider.GetRequiredService<DotNetty>());
            return service.BuildServiceProvider();
        }
    }
}
