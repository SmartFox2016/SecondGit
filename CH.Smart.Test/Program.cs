using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CH.Smart.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context=new CommDbContext())
            {
                var param = new
                {
                    Device_ID = dbGateway.Device_ID,
                    Service_ID = serverId,
                    Path = new DbString { IsAnsi = true, Value = dbGateway.Path },
                    Flags = ~DeviceStateFlags.ErrorNetwork,
                    IP = ip,
                };
                var Db = new CommandDefinition("UPDATE [Comm_Log] SET [Is_End]=1, [End_Time]=GETDATE() WHERE [Device_ID]=@Device_ID AND [Tag]='GatewayOffline' AND [Is_End]=0;",
                    parameters: param);

                var cdc = context.CommLog().ToList();
                Console.WriteLine(cdc);
            }
        }
    }
}
