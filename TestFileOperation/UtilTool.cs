using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestFileOperation
{
    class UtilTool
    {
        public static byte[] GetSendDataNew(string batteryMSG)
        {

            //string batteryMSG = "68 AE 00 AE 00 68 88 81 51 C1 FF 02 0C 61 04 01 01 10 32 16 24 02 17 04 00 20 30 03 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 7B 16";
            //batteryMSG = batteryMSG.Replace(" ","");
            List<string> batteryMSGstr = new List<string>();
            int stringNum = batteryMSG.Length / 2;
            for (int i = 0; i < stringNum; i++)
            {
                string factorStr = batteryMSG.Substring(i * 2, 2);
                batteryMSGstr.Add(factorStr);
            }

            byte[] returnBytes = new byte[stringNum];
            for (int i = 0; i < stringNum; i++)
            {
                returnBytes[i] = Convert.ToByte(batteryMSGstr.ElementAt(i), 16);
                Console.WriteLine(returnBytes[i]);
            }
            return returnBytes;
        }
    }
}
