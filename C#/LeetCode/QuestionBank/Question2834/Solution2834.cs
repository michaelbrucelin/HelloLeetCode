using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2834
{
    public class Solution2834 : Interface2834
    {
        /// <summary>
        /// 贪心 + 脑筋急转弯
        /// 1. (1, target-1), (2, target-2), ... (target/2) 中每一个数对只能取其中一个，那么取1, 2, ... target/2
        /// 2. target, target+1, ... 随便获取
        /// 
        /// 大概率会TLE，可以使用等差数组求和公式优化速度
        /// </summary>
        /// <param name="n"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int MinimumPossibleSum(int n, int target)
        {
            const int MOD = (int)1e9 + 7;
            int result = 0, cnt = 1;
            for (int i = 1; cnt <= Math.Min(n, target >> 1); i++, cnt++) result = (result + i) % MOD;
            for (int i = target; cnt <= n; i++, cnt++) result = (result + (i % MOD)) % MOD;

            return result;
        }

        /// <summary>
        /// 逻辑同MinimumPossibleSum()，只是使用了等差数组求和公式代替了循环
        /// </summary>
        /// <param name="n"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int MinimumPossibleSum2(int n, int target)
        {
            const int MOD = (int)1e9 + 7;
            long result; int half = target >> 1;
            if (n <= half)
            {
                result = ((1L + n) * n) >> 1;
            }
            else
            {
                result = ((1L + half) * half) >> 1;
                result += ((long)target + target + n - half - 1) * (n - half) >> 1;
            }

            return (int)(result % MOD);
        }
    }
}
