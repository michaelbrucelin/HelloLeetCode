using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3857
{
    public class Solution3857_2 : Interface3857
    {
        /// <summary>
        /// 贪心 + DP
        /// 逻辑同Solution3857，这里将自顶向下的记忆化搜索改为自底向上的DP
        /// DP计算了好多没用的状态
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int MinCost(int n)
        {
            if (n < 3) return n - 1;

            int m = (n + 3) >> 1;
            int[] dp = new int[m];
            dp[1] = 0; dp[2] = 1;
            for (int i = 3, j; i < m; i++)
            {
                j = i >> 1;
                dp[i] = (i & 1) == 0 ? j * j + (dp[j] << 1) : j * (j + 1) + dp[j] + dp[j + 1];
            }

            m = n >> 1;
            return (n & 1) == 0 ? m * m + (dp[m] << 1) : m * (m + 1) + dp[m] + dp[m + 1];
        }
    }
}
