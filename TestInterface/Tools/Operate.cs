using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace TestInterface.Tools
{
    class Operate
    {
        public void Add(int x,int y)
        {
            Console.WriteLine($"The result is {x+y},@{DateTimeKind.Local}");
        }
        //将字符串转为十进制数 https://zhidao.baidu.com/question/62290479.html
        public decimal SnStrConvertDecimal(string data)
        {
            decimal returnData = 0;

            bool isOdd = (data.Length % 2) == 1 ? true : false;
            if (isOdd)
            {
                int count = data.Length / 2 + 1;
                for (int i = 0; i < count; i++)
                {
                    string factorStr;
                    if (i == (count - 1)) factorStr = data.Substring(i * 2, 1);
                    else factorStr = data.Substring(i * 2, 2);
                    returnData = returnData + Convert.ToInt32(factorStr, 16) * ((int)Math.Pow(16, i)); ;
                }
            }
            else
            {
                int count = data.Length / 2;
                for (int i = 0; i < count; i++)
                {
                    string factorStr = data.Substring(i * 2, 2);
                    returnData = returnData + Convert.ToInt32(factorStr, 16) * ((int)Math.Pow(16, i)); ;
                }
            }

            return returnData;
        }
        public class DeviceManager
        {
            public ConcurrentDictionary<int, int> id2Dev = new ConcurrentDictionary<int, int>();
            public Dictionary<string, int> sn2Dev = new Dictionary<string, int>();
            //NOTE: 此处若不为ConcurrentDictionary则需ToList(), 因为可能动态增减
            public IEnumerable<int> AllDevices { get { return id2Dev.Values; } }
        }

    }
}
