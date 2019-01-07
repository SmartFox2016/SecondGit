using System;
using System.Collections.Generic;
using System.Text;

namespace TestServiceCollection.Tools
{
    class Operate
    {
    }
    public abstract partial class DotNetty
    {
        public void StartAsync()
        {
            this.Age = 100;  
            this.InitializationAction(888);
    }
        protected abstract void InitializationAction(int channel); //抽象方法不能被实现，且只能放在抽象类中

    }
}
