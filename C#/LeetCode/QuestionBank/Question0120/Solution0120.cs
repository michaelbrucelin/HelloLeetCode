using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0120
{
    public class Solution0120 : Interface0120
    {
        /// <summary>
        /// DP
        /// </summary>
        /// <param name="triangle"></param>
        /// <returns></returns>
        public int MinimumTotal(IList<IList<int>> triangle)
        {
            if (triangle.Count == 1) return triangle[0][0];

            int cnt = triangle.Count;
            int[][] dp = new int[cnt][];
            dp[0] = [triangle[0][0]];
            for (int i = 1; i < cnt; i++)
            {
                dp[i] = new int[i + 1];
                dp[i][0] = dp[i - 1][0] + triangle[i][0];
                for (int j = 1; j < i; j++) dp[i][j] = Math.Min(dp[i - 1][j - 1], dp[i - 1][j]) + triangle[i][j];
                dp[i][^1] = dp[i - 1][^1] + triangle[i][^1];
            }

            int result = dp[^1][0];
            for (int i = 1; i < cnt; i++) result = Math.Min(result, dp[^1][i]);
            return result;
        }

        /// <summary>
        /// DP
        /// 逻辑同MinimumTotal()，滚动数组，完成进阶要求，甚至可以原地（高低位存储）操作，这样更省内存
        /// </summary>
        /// <param name="triangle"></param>
        /// <returns></returns>
        public int MinimumTotal2(IList<IList<int>> triangle)
        {
            if (triangle.Count == 1) return triangle[0][0];

            int cnt = triangle.Count;
            int[] dp = new int[cnt];
            dp[0] = triangle[0][0];
            for (int i = 1; i < cnt; i++)
            {
                dp[i] = dp[i - 1] + triangle[i][i];
                for (int j = i - 1; j > 0; j--) dp[j] = Math.Min(dp[j], dp[j - 1]) + triangle[i][j];
                dp[0] = dp[0] + triangle[i][0];
            }

            int result = dp[0];
            for (int i = 1; i < cnt; i++) result = Math.Min(result, dp[i]);
            return result;
        }
    }
}
