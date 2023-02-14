using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1124
{
    public class Solution1124 : Interface1124
    {
        /// <summary>
        /// 前缀和
        /// 1. 预处理前缀和数组，例如
        ///       索引：      0   1   2   3   4   5   6   7   8   9
        ///     原数组：[     5,  6,  9,  9,  9,  6,  0,  6,  6,  9]
        ///          1：[    -1, -1,  1,  1,  1, -1, -1, -1, -1,  1]
        ///     前缀和：[0,  -1, -2, -1,  0,  1,  0, -1, -2, -3, -2]
        ///     这样使用前缀和可以O(1)的时间得出子数组是否满足结果的要求
        /// 2. 可以从大到小逐步检查各个长度的子数组中是否有结果
        ///     不可以使用二分法，例如[9,9,0,0,0,9,9]结果是7，但是6不满足结果，即不是连续单调的
        /// </summary>
        /// <param name="hours"></param>
        /// <returns></returns>
        public int LongestWPI(int[] hours)
        {
            int len = hours.Length;
            int[] precnt = new int[len + 1];
            for (int i = 0; i < len; i++) precnt[i + 1] = precnt[i] + (hours[i] > 8 ? 1 : -1);

            int result = len + 1;
            while (--result > 0)
            {
                for (int i = result; i <= len; i++)
                {
                    if (precnt[i] > precnt[i - result]) return result;
                }
            }

            return 0;
        }
    }
}
