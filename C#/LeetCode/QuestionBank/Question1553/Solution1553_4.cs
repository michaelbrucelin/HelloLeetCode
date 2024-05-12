using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1553
{
    public class Solution1553_4 : Interface1553
    {
        /// <summary>
        /// DP
        /// 本质上仍然与Solution1553逻辑一样，Solution1553相当于倒序计算，而DP相当于正序计算
        /// 
        /// 提交依然TLE
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int MinDays(int n)
        {
            if (n < 3) return n;

            int[] dp = new int[n + 1];
            for (int _i = 0; _i <= n; _i++) dp[_i] = _i;

            dp[1] = 1;
            int i = 1, l2 = n >> 1, l3 = n / 3;
            for (; i <= l3; i++)
            {
                dp[i + 1] = Math.Min(dp[i + 1], dp[i] + 1);
                dp[i << 1] = Math.Min(dp[i << 1], dp[i] + 1);
                dp[i * 3] = Math.Min(dp[i * 3], dp[i] + 1);
            }
            for (; i <= l2; i++)
            {
                dp[i + 1] = Math.Min(dp[i + 1], dp[i] + 1);
                dp[i << 1] = Math.Min(dp[i << 1], dp[i] + 1);
            }
            for (; i < n; i++)
            {
                dp[i + 1] = Math.Min(dp[i + 1], dp[i] + 1);
            }

            return dp[n];
        }
    }
}
