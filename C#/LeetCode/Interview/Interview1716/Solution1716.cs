using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Interview.Interview1716
{
    public class Solution1716 : Interface1716
    {
        /// <summary>
        /// DP
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int Massage(int[] nums)
        {
            int len = nums.Length;
            int[,] dp = new int[2, len + 1];  // 1维: 用; 2维: 不用
            for (int i = 0; i < len; i++)
            {
                dp[0, i + 1] = dp[1, i] + nums[i];
                dp[1, i + 1] = Math.Max(dp[0, i], dp[1, i]);
            }

            return Math.Max(dp[0, len], dp[1, len]);
        }

        /// <summary>
        /// DP，滚动数组
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int Massage2(int[] nums)
        {
            int len = nums.Length, use = 0, no = 0;
            for (int i = 0, _use = 0, _no = 0; i < len; i++)
            {
                _use = no + nums[i]; _no = Math.Max(use, no);
                use = _use; no = _no;
            }

            return Math.Max(use, no);
        }
    }
}
