using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0092
{
    public class Solution0092 : Interface0092
    {
        /// <summary>
        /// 枚举
        /// 枚举0与1的分界位置，借助前缀和快速计算
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int MinFlipsMonoIncr(string s)
        {
            int len = s.Length;
            int[] sums = new int[len + 1];
            for (int i = 0; i < len; i++) sums[i + 1] = sums[i] + '1' - s[i];

            int result = sums[len], cnt1 = len - sums[len - 1];
            for (int i = 0; i < len; i++) result = Math.Min(result, i + 1 - sums[i + 1] + sums[len] - sums[i + 1]);

            return result;
        }
    }
}
