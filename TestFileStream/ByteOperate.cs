using System;
using System.Text;

namespace TestFileStream.Method
{
    class ByteOperate
    {
        /// <summary>
        /// 将字符串转换成字节型数组
        /// </summary>
        /// <param name="str">传入参数</param>
        public void GetByte(string str)
        {
            Console.WriteLine(str);
            string[] fixByte = str.Split(" ");//这个方法还不一定是对的 
            Console.WriteLine("数据长度："+ fixByte.Length);
            byte[] returnBytes = new byte[fixByte.Length];
            for (int i = 0; i < fixByte.Length; i++)
            {
                returnBytes[i] = Convert.ToByte(fixByte[i],16);
                Console.Write(returnBytes[i] + " ");
            }
        }
    }
}
