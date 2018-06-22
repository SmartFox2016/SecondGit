using System;
using System.IO;
using System.Text;
using TestFileStream.Method;

namespace TestFileStream
{
    //description：读取一个文本文件
    //time:2018-05-30
    class FileOperate
    {
        /// <summary>
        /// 读取文件的方法
        /// </summary>
        /// <param name="filePath"></param>
        public void ReadFile(string filePath)
        {
            //循环读取大文本文件
            FileStream fsRead;
            //获取文件路径
            //string filePath = "C:\\Users\\Flying\\Desktop\\临时.txt";
            //用FileStream文件流打开文件
            try
            {
                fsRead = new FileStream(@filePath, FileMode.Open);
            }
            catch (Exception)
            {
                throw;
            }
            //还没有读取的文件内容长度
            long leftLength = fsRead.Length;
            //创建接收文件内容的字节数组
            byte[] buffer = new byte[1024];
            //每次读取的最大字节数
            int maxLength = buffer.Length;
            //每次实际返回的字节数长度
            int num = 0;
            //文件开始读取的位置
            int fileStart = 0;
            while (leftLength > 0)
            {
                //设置文件流的读取位置
                fsRead.Position = fileStart;
                if (leftLength < maxLength)
                {
                    num = fsRead.Read(buffer, 0, Convert.ToInt32(leftLength));
                }
                else
                {
                    num = fsRead.Read(buffer, 0, maxLength);
                }
                if (num == 0)
                {
                    break;
                }
                fileStart += num;
                leftLength -= num;
                Console.WriteLine(Encoding.UTF8.GetString(buffer));//原来的
                //Console.OutputEncoding = Encoding.GetEncoding("gbk");
                //Console.WriteLine(Encoding.Unicode.GetChars(buffer));
            }
            Console.WriteLine("The txt is read over!!!!!");
            fsRead.Close();
            
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            FileOperate fo = new FileOperate();
            //fo.ReadFile("C:\\Users\\Flying\\Desktop\\测试.txt");//11
            fo.ReadFile("C:/Users/Flying/Desktop/测试.txt");//22  备注：11和22处代码是一致的
            //string strTest = "Hello Flying I miss you very much";
            string strTest = "01 04 20 00 F1 00 EF 00 EF";

            ByteOperate byteOperate = new ByteOperate();
            byteOperate.GetByte(strTest);
            Console.ReadKey();
        }
    }
}
