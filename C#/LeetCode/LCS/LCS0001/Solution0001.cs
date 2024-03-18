using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCS.LCS0001
{
    public class Solution0001 : Interface0001
    {
        /// <summary>
        /// 贪心
        /// 可以证明，n分钟的最大值有两种可能
        ///     1. 最后1分钟下载，前面一直翻倍
        ///     2. 最后2分钟下载，前面一直翻倍
        /// x分钟可以下载2^{x-1}个插件，即2^{x-1}>=N, x >= ln N + 1
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int LeastMinutes(int n)
        {
            return (int)Math.Ceiling(Math.Log2(n)) + 1;
        }
    }
}
