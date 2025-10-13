using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3186
{
    public class Solution3186_err : Interface3186
    {
        /// <summary>
        /// DP
        /// 都错题了，题目限定的左右“两份”不能获取指的是值，这里理解为索引了
        /// </summary>
        /// <param name="power"></param>
        /// <returns></returns>
        public long MaximumTotalDamage(int[] power)
        {
            int len = power.Length;
            long[] dp = new long[len + 3];
            for (int i = 0; i < len; i++) dp[i + 3] = Math.Max(dp[i] + power[i], dp[i + 2]);

            return dp[^1];
        }
    }
}
