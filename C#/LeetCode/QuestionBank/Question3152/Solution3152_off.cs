using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3152
{
    public class Solution3152_off : Interface3152
    {
        public bool[] IsArraySpecial(int[] nums, int[][] queries)
        {
            int len = nums.Length;
            int[] dp = new int[len]; dp[0] = 1;
            for (int i = 1; i < len; i++) dp[i] = (((nums[i] ^ nums[i - 1]) & 1) != 0) ? dp[i - 1] + 1 : 1;

            len = queries.Length;
            bool[] result = new bool[len];
            for (int i = 0, from = 0, to = 0; i < len; i++)
            {
                (from, to) = (queries[i][0], queries[i][1]);
                result[i] = dp[to] >= to - from + 1;
            }

            return result;
        }
    }
}
