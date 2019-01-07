using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TestServiceCollection.Tools
{
    class AppConfig
    {
        public string CfgDir { get; private set; }
        MainConfig Main { get; set; }=new MainConfig();
        public AppConfig()
        {
             const string USE_RPC_V2 = "测试20181019";
            try
            {
                string dir, file;
                dir = Directory.GetCurrentDirectory();
                file = Path.Combine(dir, "appConfig.json");
                if (File.Exists(file))
                {
                    Load(file);
                    return;
                }
                dir = Path.GetDirectoryName(typeof(AppConfig).Assembly.Location);
                file = Path.Combine(dir, "appConfig.json");
                if (File.Exists(file))
                {
                    Load(file);
                    return;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void Load(string file)
        {
            //TODO: Use HOCON?
            var data = File.ReadAllText(file);
            var jObj = JsonConvert.DeserializeObject<JObject>(data);
            Load(jObj);

            this.CfgDir = Path.GetDirectoryName(file);
        }
/// <summary>
/// 将Json格式的数据转为.NET需要的类型 20181020
/// </summary>
/// <param name="data"></param>
//{
//  "Main": {
//    //"DbConn": "data source=(localdb)\\MSSQLLocalDB;initial catalog=SmartPower2_Comm_AC_Dev;asynchronous processing=True;multipleactiveresultsets=True;application name=CH.Smart.Comm",
//    "DbConn": "data source=123.56.160.179,2478;initial catalog=SmartPower2_Comm_AC_Dev;user id=smartpowerdev5;password=smartpowerdev5179;asynchronous processing=True;multipleactiveresultsets=True;application name=CH.Smart.Comm",
//    "ServerId": 16,
//    "IsReadonly": 1
//    }
//}
    protected virtual void Load(JObject data)
    {
        Main.Load((JObject)data[nameof(Main)]);
    }
        public class MainConfig
        {
            
            public string DbConn { get; private set; }
            public int ServerId { get; private set; }
            public bool IsReadonly { get; private set; }
            public void Load(JObject data)
            {
                this.DbConn = (string)data["DbConn"];
                this.ServerId = (int)data["ServerId"];
                var tmp = (int?)data["IsReadonly"];
                tmp = tmp ?? 1;
            }
        }
    }
}
