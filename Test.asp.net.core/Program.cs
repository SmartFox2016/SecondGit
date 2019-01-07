using System;

namespace Test.asp.net.core
{
    struct PDataGroup
    {
        public static PDataGroup PData_0 { get; } = new PDataGroup() { value = 0 };
        public static PDataGroup PData_1 { get; } = FromPSingle(1);
        private ushort value;//0x0|([01-255][01-255])
        public PDataGroup(ushort value)
        {
            this.value = value;
        }

        public ushort Raw => value;
        private byte DA1 => (byte)(this.value & 0x00FF);//信息点元 DA2和DA1共同构成信息点标示pn
        private byte DA2 => (byte)(this.value >> 8); // 信息点组                  右移8位，相当于在左边加8个零

        public static PDataGroup FromPSingle(short p)
        {
            Console.WriteLine("***");
            return new PDataGroup(1);
        }

        public byte GetBitsInByte(byte b)
        {
            //NOTE: 也可以用查表法...
            byte i = 0;
            while (b != 0)
            {
                if ((b & 0x01) != 0)
                    ++i;
                b >>= 1;
            }
            Console.WriteLine($"i={i}");
            return i;
        }
    }
    class Program
    {
        public static void FromFSingle(short f)
        {
            var da2 = (byte)((f - 1) / 8);
            Console.WriteLine($"da2={da2}");
            var y = (f - 1) % 8;//0~7
            Console.WriteLine($"y={y}");
            var da1 = (byte)(1 << y);
            Console.WriteLine($"da1={da1}");
            var raw = (ushort)((da2 << 8) | da1);
            Console.WriteLine($"raw={raw}");
        }
        static void Main(string[] args)
        {
            Program p = new Program();
            Program.FromFSingle(1);
            ushort DA = 28;
            //详见 https://blog.csdn.net/yongjunhe/article/details/8500405
            Console.WriteLine($"信息点DA{DA:X}H");//将其转换为16进制数（）
            Console.WriteLine($"信息点DA{DA:X2}H");//将其转换为 xx 16进制数
            Console.WriteLine($"信息点DA{DA:X4}H");//将其转换为 xxxx 16进制数
            Console.WriteLine($"信息点DA{DA:X8}H");//将其转换为 xxxx 16进制数
            PDataGroup PDatas = new PDataGroup(10);
            PDatas.GetBitsInByte(10);
            Console.ReadKey();
        }
    }
}
