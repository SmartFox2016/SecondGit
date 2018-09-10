using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Test.Byte1;
using TestOther;

namespace Test.Byte1.Array
{
    class Dog
    {
        public int Age{ get; set; }
        public int Weight { get; set; }
        public String Name { get; set; }
    }

    class Person
    {
        public int Age { get; set; }
        public int Weight { get; set; }
        public String Name { get; set; }
    }

    class Program
    {
        //定义成员方法，只是这个成员方法的类型是Dog
        private static Person HHD()
        {
            return new Person
            {
                Age=1,
                Name="Flying",
            };
        }

        //public static String cvtStr2Hex(String str)
        //{
        //    if (str == null) return "";
        //    StringBuilder sb = new StringBuilder("");
        //    for (int i = 0; i < str.Length; i++)
        //    {
        //        byte[] ba = str.Substring(i, i + 1).getBytes();
        //        String tmpHex = Integer.toHexString(ba[0] & 0xFF);
        //        sb.append("0x" + tmpHex.toUpperCase() + " ");
        //        if (ba.length == 2)
        //        {
        //            tmpHex = Integer.toHexString(ba[1] & 0xff);
        //            sb.append("0x" + tmpHex.toUpperCase() + " ");
        //        }
        //    }
        //    //转换的时候一定注意将自己的文件编码改成GBK
        //    return sb.toString();
        //}

        //public static String cvtStr2Hex2(String str)
        //{
        //    if (str == null)
        //        return "";
        //    StringBuilder sb = new StringBuilder("");
        //    for (int i = 0; i < str.Length/ 2; i++)
        //    {
        //        String sub = str.Substring(i * 2, i * 2 + 2);
        //        sb.Append("0x" + sub.toUpperCase() + " ");
        //    }
        //    // 转换的时候一定注意将自己的文件编码改成GBK
        //    return sb.ToString();
        //}
        public static string[] Method(string str)
        {
            //string[] parts = str.Split("&");
            string[] parts = str.Split(new char[]{ '&' });

            foreach (var item in parts)
            {
                Console.WriteLine(item);
            }
            return parts;
        }

        public static int? GetRequst(string model)
        {
            int? aa=null;
            switch (model)
            {
                case "Switch_Model":
                    aa = 1;
                    break;
                case "Work_Model":
                    aa = 2;
                    break;
            }
            return aa;

        }
        static int n;
        public static int GetRequst2(string model)
        {
            switch (model)
            {
                case "Switch_Model":
                    Program.n = 1;
                    break;
                case "Work_Model":
                    Program.n = 2;
                    break;
            }
            return n;
        }
        static int m;
        public static int GetRequst3(string model)
        {
            //int m;
            if (model.Equals("Switch_Model"))
            {
                Program.m = 1;
            }
            if (model.Equals("Work_Model"))
            {
                Program.m = 2;
            }
            return m;
        }

        public static void GetByte(Byte[] msg)
        {
            foreach (var item in msg)
            {
                Console.Write(item+", " );
            }
        }

        public static int Method2(int  str)
        {
            try
            {
                if (str == 4)
                {
                    return str;
                }
                return str = 5;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                Console.WriteLine("----正在运行方法Method2----");
            }
            
        }
        public static void Method3(int str)
        {
            try
            {
                if (str == 4)
                {
                    if (true)
                    {
                        Console.WriteLine("第一步");
                    }
                }
                Console.WriteLine("第二步");
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                Console.WriteLine("----正在运行方法Method3----");
            }

        }
        //功能：读取一个字节的BCD码
        public static byte? deBCD8421(byte data)
        {
            if (data == 0xEE) return null;
            var lo = data & 0x0f;
            if (lo >= 10) throw new InvalidDataException("无效的BCD8421编码");
            var hi = data >> 4;
            if (hi >= 10) throw new InvalidDataException("无效的BCD8421编码");
            return (byte)(hi * 10 + lo);
        }

        //这个方法用来计算校验和
        public static byte ChkSum8( byte[] data)
        {
            byte chksum8 = 0;
            
            for (int i = 0; i < data.Length; i++)
            {
                chksum8 += data[i];
            }
            return chksum8;
        }

        public static byte[] Str2Byte(string model, string str)
        {
            List<string> strList = new List<string>();
            int strLen = str.Length / 2;
            for (int i = 0; i < strLen; i++)
            {
                string factorStr = str.Substring(i * 2, 2);
                strList.Add(factorStr);
            }
            byte[] result = new byte[strLen];
            int CycleM5 = 0;
            for (int i = 0; i < strLen; i++)
            {
                result[i] = Convert.ToByte(strList.ElementAt(i), 16);
                if (model.Equals("DTU_Upload"))
                {
                    //if (i <= strLen - 2)
                    //{
                    //    if (result[i + 1] < 5)
                    //    {
                    //       ++CycleM5;
                    //    }
                    //}
                    if (i <= strLen - 2&& result[i + 1] < 5)
                    {
                        ++CycleM5;
                    }
                }
            }
            if (CycleM5 >= 1)
            {
                throw new InvalidDataException("设置的上报周期不能小于5");
            }
            return result;
        }


        static void Main(string[] args)
        {
            //byte[] testByte = new byte[]{ 0xC9, 0x01 , 0x00 , 0x00 , 0x00 , 0x00 , 0x02 , 0xE0 , 0x00 , 0x00 , 0x04 , 0x00};

            //var 测试 = Program.Str2Byte( "DTU_Upload", "0f02030405");
            //Console.WriteLine($"测试结果={测试}");
            Program.Method3(4);
            int m =1, n=1;
            Console.WriteLine($"m={++m},n={n++}");
            //byte[] testByte=new byte[] { 0x88, 0x02, 0x00, 0x00, 0x00, 0x0C, 0x61, 0x04, 0x01, 0x02,
            //    0x0e, 0x32, 0x16, 0x24, 0x02, 0x17, 0x04, 0x00, 0x20, 0x30, 0x03, 0x00, 0x00, 0x00,
            //    0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
            //    0x00, 0x00, 0x00, 0x00 };
            byte[] testByte = new byte[] { 0xC9, 0x01, 0x00, 0x00, 0x00, 0x00, 0x02, 0x70, 0x00, 0x00, 0x01, 0x00 };
            var CS  = Program.ChkSum8(testByte);
            if (CS!=61)
            {
                throw new InvalidDataException("值不相等");
            }
            Console.WriteLine($"CS={CS}");
            //byte BCD = 0xC1;
            var BCD = Program.deBCD8421(0x31);
            Console.WriteLine($"BCD={BCD}");

            var data =Program.Method2(4);
            Console.WriteLine($"data={data}");
            Program.GetByte(new byte[] { 0x01,0x0,0x03,0x04,0x10});
            //https://zhidao.baidu.com/question/62290479.html
            var re=Program.Method("Ctl.IR.AC&Work_Model");
            if (re[1].Equals("Work_Model"))
            {
                Console.WriteLine("工作模式");
            }
            var mm = Program.GetRequst2(re[1]);
            Console.WriteLine($"mm={mm}");
            string str4 = "D010";
            var result= UtilTool.GetSendDataNew(str4);
            Console.WriteLine("---:" + result[0]+", "+result[1]);

            Console.WriteLine("十进制:" + Convert.ToInt32(str4, 16));

            str4.Substring(0);
            string str2 = "0xD00x10";
            //string[] part2 = str2.Split("0x".ToCharArray());
            string[] part2 = str2.Split("0x"); 

            //Console.WriteLine(part2[0]);
            foreach (var item in part2)
            {
                Console.WriteLine(item);
            }
            string str3=null;
            if (part2.Length == 1)
            {
                str3 = part2[0];
            }
            else
            {
                for (int i = 0; i < part2.Length - 1; i++)
                {
                    str3 = string.Concat(str3, part2[i + 1]);
                }
            }
            
            //string str3 = string.Concat(part2[1], part2[2]);

            Console.WriteLine("拼接结果:"+str3+" 十进制:"+ Convert.ToInt32(str3, 16));
            
            Program pr = new Program();
            string str = "0x01,0x00,0x0D,40";
            //var result = pr.Method(str);
            string[] parts = str.Split(',');
           // Console.WriteLine(Convert.ToByte(result[3], 16));
            Console.WriteLine("-----------");
            foreach (var item in parts)
            {
                Console.WriteLine(item);
                Console.WriteLine(Convert.ToByte(item, 16));
            }


            TestReference testReference = new TestReference();
            testReference.GetAdd(99,1);
            Console.WriteLine( Program.HHD().Name);
            Console.WriteLine(Program.HHD());

            byte[] tstBy = new byte[] {1,2,3,4 };
            Console.WriteLine(string.Join(",",tstBy));
            //实例化类的两种方法
            var dog = new Dog { //方法①
                Age = 10,
                Name="Hello",
                Weight=12,
            };
            var dog2 = new Dog(); //方法②
            dog2.Name = "wang-wang";
            Console.WriteLine(nameof(dog.Age));
            Console.WriteLine(dog.Age+""+dog2.Name);
            Console.WriteLine(dog.Age+""+dog2.Name);
            Console.WriteLine($"年龄是{dog.Age},名字是{dog.Name}" );
            Console.WriteLine("年龄是{0}，名字是{1}",dog.Age,dog.Name);
            List<Byte> operateCode = new List<Byte>();
            operateCode.Add(4);//功能码  
            operateCode.Add(0x00);//1 (1和2组合，可设置CT变化)
            operateCode.Add(0x64);//2
            operateCode.Add(0x00);//3(3和4组合，可设置电压额定值)
            operateCode.Add(0xDC);//4
            byte[] SourceOperator = new byte[] { operateCode[1], operateCode[2], operateCode[3], operateCode[4] };
            Console.WriteLine(SourceOperator.Length);
            foreach (var item in SourceOperator)
            {
                Console.Write(item + "- ");
            }
            Console.WriteLine("取元素"+SourceOperator);
            //for (int i = 0; i < SourceOperator.Length; i++)
            //{
                Console.WriteLine(SourceOperator[3]);
            //}
            GetByte(operateCode);
            Console.ReadKey();
        }

        private static byte[] GetByte(List<Byte> funCode)
        {
            //byte[] SourceOperator = new byte[funCode.Capacity - 3];
            byte[] SourceOperator = new byte[] { funCode[0], funCode[1],funCode[2], funCode[3], funCode[4] };

            foreach (var item in SourceOperator)
            {
                Console.Write(item + " ");
            }
            //Console.WriteLine(SourceOperator[1]);
            return SourceOperator;
        }
    }

    
}
