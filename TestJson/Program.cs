using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace TestJson
{
    public static class JsonCfg
    {
        private static readonly JsonSerializerSettings jsonSet;
        static JsonCfg()
        {
        }
        private static JsonSerializerSettings CreateDefaultSettings()
        {
            var cfg = new JsonSerializerSettings
            {
                //DefaultValueHandling = DefaultValueHandling.Ignore,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            };
            //cfg.Converters.Add(new DebugableConverter());
            //cfg.Converters.Add(new IPAddressConverter());
            //cfg.Converters.Add(new ActionIDConverter());
            //cfg.Converters.Add(new StringEnumConverter());
            //cfg.Converters.Add(new ByteBufferConverter());
            return cfg;
        }

    }

    public class DataCtl
    {
        public string Inst { get; set; }
    }
    public class Person
    {
        int Age=12;
        string Name { set; get; } = "Flying";
        string Sex { set; get; } = "Man";
    }

    class Program
    {
        public string Metod22(string UID)
        {
            var uid = uint.Parse(UID);
            var test = uid >> 16;
            var test2 = 1u >> 16;
            var a1 = (uid >> 16) & 0x0000FFFF;
            var a2 = uid & 0x0000FFFF;
            var sn = a1.ToString("X4") + a2.ToString("00000");
            return sn;
        }

        public  uint GetBitsValue(uint data, byte idx, byte len = 1)
        {
            if (len == 0) throw new ArgumentException("len can't be 0.", nameof(len));
            if (idx + len > 32) throw new ArgumentException("(idx + len) can't be greater than 32.", nameof(len));
            //var test1 = (data >> idx);
            //var test2 = (1u << len) - 1;
            return (data >> idx) & ((1u << len) - 1);
            //return (data>>idx)&1;
        }
        
        static void Main(string[] args)
        {
            Program p = new Program();
            //p.Metod22("0907000303");
            int a=63;
            byte c = (byte)a;
            byte b = 0x63;
            var result0 = p.GetBitsValue(b, 2, 1);
            var result1 = p.GetBitsValue(b, 0, 1);
            List<int> test = new List<int>();
            int d = 0;
            for (int i = 0; i < 3; i++)
            {
                d = i;
                test.Add(d);
            }
            List<FanState1> fanStates1 = new List<FanState1>();
            List<FanState2> fanStates2 = new List<FanState2>();
            for (int i = 0; i < 2; i++)
            {
                FanState1 fan = new FanState1();
                fan.boardNo = i;
                fan.fanHighState1 = "High";
                fanStates1.Add(fan);
            }
            for (int i = 0; i < 2; i++)
            {
                FanState2 fan = new FanState2();
                fan.boardTemp = i;
                fan.fanHighState2 = "Low";
                fanStates2.Add(fan);
            }
            //for (int i = 0; i < 2; i++)
            //{
            //    FanState fs = new FanState();
            //    fs.boardNo = fanStates1[i].boardNo;
            //    fs.fanHighState1 = fanStates1[i].fanHighState1;
            //    fs.boardTemp = fanStates2[i].boardTemp;
            //    fs.fanHighState2 = fanStates2[i].fanHighState2;
            //}

            Colleage colleage = new Colleage();
            Student stu = new Student()
            {
                ID = 1,
                Name="Flying"
            };
            School school = new School()
            {
                ID = 00,
                Name = "Gogogo"
            };
            colleage.CStudent = JsonConvert.SerializeObject(stu);
            colleage.CSchool = JsonConvert.SerializeObject(school);
            var mm = JsonConvert.SerializeObject(colleage);
            stu.school = new School() {ID=027,Name="成都七中" };
            //https://blog.csdn.net/u011127019/article/details/51706619
            var jsonResult = JsonConvert.SerializeObject(stu);//结果为：{"ID":1,"Name":"Flying","school":{"ID":27,"Name":"成都七中"}}
            Console.WriteLine(jsonResult);
            var jsonResult2 = JObject.FromObject(stu);
            /*jsonResult2的结果为
             * {
                "ID": 1,
                "Name": "Flying",
                "school": {
                    "ID": 27,
                "Name": "成都七中"
                }
            }*/
            Console.WriteLine(jsonResult2);
            var jsonResult3 = JsonConvert.DeserializeObject(jsonResult);
            
            var jsonResult4 = JsonConvert.DeserializeObject<Student>(jsonResult);//把Json格式转为指定的Student类型
            StringBuilder sb = new StringBuilder(); 
            sb.Append(jsonResult4.Name +"\t");
            sb.Append(jsonResult4.school.Name+"\r\n\r\n" );
            Console.WriteLine(sb);
            //对匿名对象(Anonymous object)序列化成json字符串
            var obj = new { ID=8,Name="Tom" };
            var jsonResult5 = JsonConvert.SerializeObject(obj);
            Console.WriteLine("jsonResult5" + jsonResult5);
            //DeserializeAnonymousType 将json格式还原成对象
            var obj2 = JsonConvert.DeserializeAnonymousType(jsonResult5,obj);
            var obj3 = JsonConvert.DeserializeAnonymousType(jsonResult5,new {ID=default(int),Name=default(string) } );
            var obj4 = JsonConvert.DeserializeAnonymousType(jsonResult5, new Student());
            
            

            List<string,int> sortList;
            List<(int, int)> sortList3 = new List<(int, int)>();//泛型，这个很强大
            sortList3.Add((1, 1));
            sortList3.Add((2, 2));
            Console.WriteLine(sortList3.IndexOf((2,3)));
            DataCtl dc = new DataCtl();
            //主要
            if (dc is DataCtl m)
            {
                Console.WriteLine("判断正确");
            }      

            var data = new DataCtl { Inst="010203" };
            


            var strTest1 =  JObject.FromObject (p);
            var strTest = (string)data.ConvertTo<JObject>()["Inst"];
            Console.WriteLine(strTest);
            Console.ReadKey();
        }
    }
}
