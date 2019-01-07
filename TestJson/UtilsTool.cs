using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestJson
{
    public static class ResultModelUtils
    {
        public static T ConvertTo<T>(this object data)
            where T : class
        {
            if (data == null)
                return null;

            if (data is T t)
                return t;

            if (data is JToken jt)
                return jt.ToObject<T>();

            if (data is string s)
                return JsonConvert.DeserializeObject<T>(s);

            //throw
            return (T)data;
        }
    }
    public class ResultModel<T>
    {
        public T Data { get; set; }
        public DateTime? Time { get; set; }
        public string Msg { get; set; }
    }
    /// <summary>
    /// 创建学生实体
    /// </summary>
    public class Student
    {
        public string sex { get; set; }
        public int ID { get; set; }
        public string Name { get; set; }
        public School school { get; set; }
    }

    public class School
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
    public class Colleage
    {
        public string CStudent { get; set; }
        public string CSchool { get; set; }
    }
    public class FanState1
    {
        public int boardNo { get; set; }
        public string fanHighState1 { get; set; }
    }
    public class FanState2
    {
        public int boardTemp { get; set; }
        public string fanHighState2 { get; set; }
    }
    
    public class FanState
    {
        public int boardTemp { get; set; }
        public string fanHighState2 { get; set; }
        public int boardNo { get; set; }
        public string fanHighState1 { get; set; }
    }
}
