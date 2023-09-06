using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0673
{
    public class Solution0673 : Interface0673
    {
        /// <summary>
        /// DP
        /// 使用一个二维数组，记录一数组中每一项结尾的递增子序列，不同长度的数目，例如：
        ///  1    3    5    4    7
        /// 1:1  1:1  1:1  1:1  1:1
        ///      2:1  2:2  2:2  2:4
        ///           3:1  3:1  3:5
        ///                     4:2
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int FindNumberOfLIS(int[] nums)
        {
            int len = nums.Length;
            int[][] dp = new int[len][];
            for (int i = 0; i < len; i++) dp[i] = new int[i + 2];  // id为0的位置浪费掉
            int[] cnts = new int[len + 1];                         // id为0的位置浪费掉

            for (int i = 0; i < len; i++)
            {
                dp[i][1] = 1; cnts[1]++;
                for (int j = 0; j < i; j++) if (nums[j] < nums[i]) for (int k = 1; k < dp[j].Length; k++)
                        {
                            dp[i][k + 1] += dp[j][k];
                            cnts[k + 1] += dp[j][k];
                        }
            }

            for (int i = cnts.Length - 1; i >= 0; i--)
                if (cnts[i] > 0) return cnts[i];
            return -1;
        }
    }
}
