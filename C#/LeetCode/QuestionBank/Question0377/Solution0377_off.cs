using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0377
{
    public class Solution0377_off : Interface0377
    {
        /// <summary>
        /// DP
        /// 本质上就是爬楼梯，有BFS(Solution0377)的逆运算的味道
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int CombinationSum4(int[] nums, int target)
        {
            int[] dp = new int[target + 1]; dp[0] = 1;
            for (int i = 1; i <= target; i++) foreach (int num in nums)
                {
                    if (num <= i) dp[i] += dp[i - num];
                }

            return dp[target];
        }
    }
}
