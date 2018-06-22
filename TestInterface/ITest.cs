using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CHJSZX.Worker
{
    interface ITestable
    {
        /// <summary>
        /// 异步操作方法
        /// </summary>
        /// <param name="x">参数1</param>
        /// <param name="y">参数2</param>
        /// <returns></returns>
        Task<int> ExecuteAsyn(int x,int y);
    }
}
