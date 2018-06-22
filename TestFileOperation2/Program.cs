using System;
using System.Collections.Generic;
using System.IO;

namespace TestFileOperation2
{
    class Program
    {
        /*
         * description:凭记忆仿写前一个程序
         * time：2018-04-08 AM
         */
        static void Main(string[] args)
        {
             List<int> list = new List<int> { 1, 2 };
            list.Add(4);
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
            string path = AppContext.BaseDirectory;
            StreamWriter sw = new StreamWriter(new FileStream("FileOperation.txt",FileMode.Append));
            Console.WriteLine(path);
            try
            {
                sw.WriteLine();
                sw.Write("根目录："+path);
                getDirector(sw,path,2);
                Console.WriteLine("遍历完毕！！");
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                if (sw!=null)
                {
                    sw.Close();
                }
            }
            Console.ReadKey();
        }
        public static void getDirector(StreamWriter sw,string path,int indent)
        {
            getFileName(sw,path,2);
            DirectoryInfo directoryInfo = new DirectoryInfo(path);
            foreach (var item in directoryInfo.GetDirectories())
            {
                for (int i = 0; i < indent; i++)
                {
                    sw.Write("  ");
                }
                sw.WriteLine("文件夹："+item.Name);
                getFileName(sw, path, 2);
            }
        }

        private static void getFileName(StreamWriter sw, string path, int indent)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(path);
            foreach (var item in directoryInfo.GetFiles())
            {
                for (int i = 0; i < indent; i++)
                {
                    sw.Write("  ");
                }
                sw.WriteLine(item.Name);
            }
        }
    }
}
