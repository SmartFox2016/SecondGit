using System;
using System.IO;
using System.Threading;

namespace TestFileOperation
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * description:递归地输出当前运行程序所在的磁盘下的所有文件名和子目录名，
             *      并将结果保存在指定的txt文件中
             * time:2018-04-04
             */
            //注意操作文件流时，一定要用finally块对其关闭
            string path = Directory.GetCurrentDirectory();
            string path2 = path.Substring(0,3);//取盘符（这个语句目前没用到）
            StreamWriter sw=null;
            //try
            //{
            //    //sw.WriteLine("1" );
            //    //创建输出流，将得到文件名子目录名保存到txt中
            //    sw = new StreamWriter(new FileStream("files.txt", FileMode.Append));
            //    sw.WriteLine("根目录：" + path);
            //    getDirectory(sw, path, 2);
            //}
            //catch (Exception e)
            //{

            //    Console.WriteLine("错误信息为："+e.Message);
            //}finally
            //{
            //    if (sw!=null)
            //    {
            //        sw.Close();
            //        Console.WriteLine("完成！！！");
            //    }
            //}
            //Console.WriteLine(path);
            
            //using==try finally和上面的功能相同，缺点是不能catch捕获异常
            using (sw = new StreamWriter(new FileStream("files.txt", FileMode.Append)))
            {
                sw.WriteLine();
                sw.WriteLine("--------开始执行" + DateTime.Now + "-------");
                sw.WriteLine("根目录：" + path);
                getDirectory(sw, path, 2);
                sw.WriteLine("--------执行完毕"+DateTime.Now+"-------");
                Console.WriteLine("完成！！！");
            }
            Console.ReadKey();
        }
        //获得指定路径下所有子目录名
        public static void getDirectory(StreamWriter sw, string path, int indent)
        {
            getFileName(sw, path, indent);
            DirectoryInfo root = new DirectoryInfo(path);
            foreach (DirectoryInfo d in root.GetDirectories())
            {
                for (int i = 0; i < indent; i++)
                {
                    sw.Write("  ");
                }
                sw.WriteLine("文件夹：" + d.Name);
                getDirectory(sw, d.FullName, indent + 2);
                //sw.WriteLine();
            }
        }
        /*
         * 获得指定路径下所有文件名
         * StreamWriter sw  文件写入流
         * string path      文件路径
         * int indent       输出时的缩进量
         */
        public static void getFileName(StreamWriter sw, string path, int indent)
        {
            DirectoryInfo root = new DirectoryInfo(path);
            foreach (FileInfo f in root.GetFiles())
            {
                for (int i = 0; i < indent; i++)
                {
                    sw.Write("  ");
                }
                var name = f.Name;
                sw.WriteLine(f.Name);
            }
        }
    }
}
