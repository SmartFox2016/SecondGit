using System;
using System.Collections.Generic;
using System.Text;

namespace TestAttribute
{
    [AttributeUsage(AttributeTargets.Property|AttributeTargets.Field)]
    public class ActionGroupInfoAttribute:Attribute
    {
        
                public byte AFN { get; set; }
        public short F { get; set; }

        /// <summary>
        /// 请求数据区类型
        /// </summary>
        public Type RequestDataType { get; set; }

        /// <summary>
        /// 返回数据区类型, 不设置代表返回Ack/Err, 而不是空(这会影响ActionGroup的返回数据ActionID的生成)
        /// </summary>
        public Type ResponseDataType { get; set; }

        public bool RequestByDev { get; set; }

        public string Description { get; set; }
        public ActionGroupInfoAttribute(byte afn, short f, Type reqType, Type respType, string desc = null, bool reqByDev = false)
        {
            this.AFN = afn;
            this.F = f;
            this.RequestDataType = reqType;
            this.ResponseDataType = respType;
            this.Description = desc;
            this.RequestByDev = reqByDev;
            Console.WriteLine($"AFN={afn},F={f},Desc={desc}");
        }

    }

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class SpecialActionAttribute : Attribute
    {
        public byte AFN { get; set; }
        public short F { get; set; }
        public bool IsPRM { get; set; }
        public bool? IsDev { get; set; }//对ActionIDGroup, 可从ActionGroupInfo继承
        
    }

    public class AirControllerBuilder
    {
        public AirControllerBuilder() { }

        public bool? Power { get; set; } = true;
        public byte? Temp { get; set; } = 24;
        /// <summary>
        /// 风量/风速:0-3; 0->自动,1->低, 2->中, 3->高
        /// </summary>
        public byte? WindForce { get; set; } = 0;

        /// <summary>
        /// 垂直风向:0-4 0->自动,位置:1-4摆风(实际1~3->下~上)
        /// </summary>
        public byte? WindDirectionY { get; set; } = 0;

        /// <summary>
        /// 水平风向:0-4 0->自动,位置:1-3摆风
        /// </summary>
        public byte? WindDirectionX { get; set; } = 0;
        /// <summary>
        /// (中央空调)锁定控制, 默认false
        /// </summary>
        public bool? WithLock { get; set; } = false;
        public bool Vaildate(bool doThrow, bool doFix)
        {
            Exception err = null;
            do
            {
               

                if (Temp.HasValue && (Temp.Value < 16 || Temp.Value > 32))
                {
                    err = new ArgumentException("不支持的温度" + Temp, nameof(Temp));
                    if (!doFix)
                    {
                        break;
                    }
                    else
                    {
                        if (Temp.Value < 16)
                            Temp = 16;
                        else
                            Temp = 32;
                    }
                }

                if (WindForce.HasValue && WindForce.Value > 3)
                {
                    err = new ArgumentException("不支持的风力" + WindForce, nameof(WindForce));
                    if (!doFix)
                    {
                        break;
                    }
                    else
                    {
                        WindForce = 0;
                    }
                }

                if (WindDirectionY.HasValue && WindDirectionY.Value > 3)
                {
                    err = new ArgumentException("不支持的垂直风向" + WindDirectionY, nameof(WindDirectionY));
                    if (!doFix)
                    {
                        break;
                    }
                    else
                    {
                        WindDirectionY = 0;
                    }
                }

                if (WindDirectionX.HasValue && WindDirectionX.Value > 3)
                {
                    err = new ArgumentException("不支持的水平风向" + WindDirectionX, nameof(WindDirectionX));
                    if (!doFix)
                    {
                        break;
                    }
                    else
                    {
                        WindDirectionY = 0;
                    }
                }
            }
            while (false);

            if (err == null)
            {
                return true;
            }
            else
            {
                if (doThrow)
                    throw err;

                return false;
            }
        }
    }
}
