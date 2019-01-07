using System;
using System.Collections.Generic;
using System.Text;

namespace TestBaseThis
{
    public abstract class BaseProtocolHandler
    {
        public virtual void OnNewOnlineUnsafe()
        {
            Console.WriteLine("调用了BaseProtocolHandler");
        }
    }

    public abstract class GDW3761BsaeProtocolHandler:BaseProtocolHandler
    {
        //protected override void OnNewOnlineUnsafe()
        public  override void OnNewOnlineUnsafe()
        {
            base.OnNewOnlineUnsafe();
            Console.WriteLine("2");
        }
    }
    public class ProtocolHandler:GDW3761BsaeProtocolHandler
    {
        public override void OnNewOnlineUnsafe()
        {
            base.OnNewOnlineUnsafe();
            Console.WriteLine($"1  @{DateTime.Now}");
        }
    }
}
