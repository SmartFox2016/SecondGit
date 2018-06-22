using System;
using System.Collections.Generic;
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
        static void Main(string[] args)
        {
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
