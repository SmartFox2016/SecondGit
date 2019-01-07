using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace TestAttribute
{
    class UntilTool
    {
        public static AirControllerBuilder Method(string inst)
        {
            if (string.IsNullOrEmpty(inst))
                return null;
            if (inst.Length < 6 || inst.Length > 8)
                throw new ArgumentException("无效的红外码");
            //先验证下红外码的范围, 简化十六进制转换的逻辑
            if (inst.Any(c => !((c >= '0' && c <= '9') || (c >= 'A' && c <= 'F') || (c >= 'a' && c <= 'f'))))
                throw new ArgumentException("无效的红外码");
            var data = new AirControllerBuilder();
            byte tmpB;

            //NOTE: 在原版精益中, 9在Power/Mode/WindForce中表示"未知"
            tmpB = ParseHex(inst[0]);
            if (tmpB != 0x0F)
            {
                if (tmpB > 1 && tmpB != 9)
                    throw new ArgumentException("无效的开关状态" + inst[0]);
                data.Power = tmpB == 1;
            }
            else
            {
                data.Power = null;
            }

            tmpB = ParseHex(inst[1]);
            //data.Mode = (tmpB != 0x0F) ? (AirControllerMode?)tmpB : null;

            tmpB = (byte)((ParseHex(inst[2]) << 4) + ParseHex(inst[3]));
            data.Temp = (tmpB != 0xFF) ? (byte?)(tmpB + 16) : null;

            tmpB = ParseHex(inst[4]);
            data.WindForce = (tmpB != 0x0F) ? (byte?)tmpB : null;

            tmpB = ParseHex(inst[5]);
            data.WindDirectionY = (tmpB != 0x0F) ? (byte?)tmpB : null;

            do
            {
                if (inst.Length < 7)
                    break;

                tmpB = ParseHex(inst[6]);
                data.WindDirectionX = (tmpB != 0x0F) ? (byte?)tmpB : null;

                if (inst.Length < 8)
                    break;

                tmpB = ParseHex(inst[7]);
                data.WithLock = (tmpB != 0x0F) ? ((tmpB & 0x01) != 0) : default(bool?);
            } while (false);
            //验证合法性
            data.Vaildate(true, false);
            return null;
        }

        private static byte ParseHex(char c)
        {
            if (c >= '0' && c <= '9')
                return (byte)(c - '0');
            if (c >= 'A' && c <= 'F')
                return (byte)(c - 'A' + 10);
            if (c >= 'a' && c <= 'f')
                return (byte)(c - 'a' + 10);
            //越界
            throw new InvalidDataException("无效Hex字符: " + c);
        }

    }
}
