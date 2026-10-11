using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0279
{
    public class Solution0279 : Interface0279
    {
        /// <summary>
        /// DP
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int NumSquares(int n)
        {
            int sqrt = (int)Math.Sqrt(n);
            if (sqrt * sqrt == n) return 1;

            List<int> sqrs = [0];
            for (int i = 1, j; (j = i * i) <= n; i++) sqrs.Add(j);

            int[] dp = new int[n + 1];
            dp[1] = 1;
            for (int i = 2, cnt = sqrs.Count; i <= n; i++)
            {
                dp[i] = i;
                for (int j = 1; j < cnt && sqrs[j] <= i; j++) dp[i] = Math.Min(dp[i], dp[i - sqrs[j]] + 1);
            }

            return dp[n];
        }
    }
}
