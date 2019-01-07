using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace Test.Serialize
{
    class Student
    {
        public int ID { get; set; } = 1;
        public string Name { get; set; } = "Flying";
    }
    class Program
    {
        static void Main(string[] args)
        {
            string srt = "ceshi";
            var res = new JObject();
            //res[str] = new JObject
            //{
            //    []
            //} JsonConvert.SerializeObject();

            Console.WriteLine();
            Console.WriteLine("Hello World!");
        }
    }
}
