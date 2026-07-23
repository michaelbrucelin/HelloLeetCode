using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2771
{
    public class Solution2771 : Interface2771
    {
        /// <summary>
        /// DP
        /// 代码可优化，例如
        ///   1. 大于等于max，就一定大于等于min，就不需要比较了，但是代码不好看，这里就不做了
        ///   2. 滚动数组
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="nums2"></param>
        /// <returns></returns>
        public int MaxNonDecreasingLength(int[] nums1, int[] nums2)
        {
            int result = 1, len = nums1.Length;
            int[,] dp = new int[len, 4];
            dp[0, 0] = Math.Min(nums1[0], nums2[0]);
            dp[0, 2] = Math.Max(nums1[0], nums2[0]);
            dp[0, 1] = dp[0, 3] = 1;
            for (int i = 1, min, max; i < len; i++)
            {
                dp[i, 0] = min = Math.Min(nums1[i], nums2[i]);
                dp[i, 2] = max = Math.Max(nums1[i], nums2[i]);
                dp[i, 1] = dp[i, 3] = 1;
                if (min >= dp[i - 1, 0]) dp[i, 1] = dp[i - 1, 1] + 1;
                if (min >= dp[i - 1, 2]) dp[i, 1] = dp[i - 1, 3] + 1;
                if (max >= dp[i - 1, 0]) dp[i, 3] = dp[i - 1, 1] + 1;
                if (max >= dp[i - 1, 2]) dp[i, 3] = dp[i - 1, 3] + 1;
                result = Math.Max(result, Math.Max(dp[i, 1], dp[i, 3]));
            }

            return result;
        }
    }
}
