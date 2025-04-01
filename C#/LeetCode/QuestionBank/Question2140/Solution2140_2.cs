using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2140
{
    public class Solution2140_2 : Interface2140
    {
        /// <summary>
        /// DP
        /// 逻辑同Solution2140，将DFS改为DP
        /// </summary>
        /// <param name="questions"></param>
        /// <returns></returns>
        public long MostPoints(int[][] questions)
        {
            int len = questions.Length;
            long[] dp = new long[len];
            dp[len - 1] = questions[len - 1][0];
            long yes, no;
            for (int i = len - 2; i >= 0; i--)
            {
                yes = questions[i][0] + (i + questions[i][1] + 1 < len ? dp[i + questions[i][1] + 1] : 0);
                no = dp[i + 1];
                dp[i] = Math.Max(yes, no);
            }

            return dp[0];
        }
    }
}
