using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0127
{
    public class Solution0127 : Interface0127
    {
        /// <summary>
        /// 递归
        /// 
        /// 逻辑没问题，TLE，可添加记忆化搜索加速，这里就不写了，直接DP
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public int TrainWays(int num)
        {
            if (num == 0) return 1; else if (num < 3) return num;

            return TrainWays(num - 1) + TrainWays(num - 2);
        }
    }
}
