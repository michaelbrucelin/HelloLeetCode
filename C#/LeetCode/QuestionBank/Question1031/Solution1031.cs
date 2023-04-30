using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1031
{
    public class Solution1031 : Interface1031
    {
        /// <summary>
        /// 前缀和 + DP
        /// 具体见Solution1031.md
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="firstLen"></param>
        /// <param name="secondLen"></param>
        /// <returns></returns>
        public int MaxSumTwoNoOverlap(int[] nums, int firstLen, int secondLen)
        {
            int len = nums.Length;
            int[] pre = new int[len + 1], max1 = new int[len], max2 = new int[len];
            for (int i = 0; i < len; i++) pre[i + 1] = pre[i] + nums[i];
            int window = nums[0..firstLen].Sum(); max1[firstLen - 1] = window;
            for (int i = firstLen; i < len; i++)
            {
                window = window - nums[i - firstLen] + nums[i];
                max1[i] = Math.Max(max1[i - 1], window);
            }
            window = nums[0..secondLen].Sum(); max2[secondLen - 1] = window;
            for (int i = secondLen; i < len; i++)
            {
                window = window - nums[i - secondLen] + nums[i];
                max2[i] = Math.Max(max2[i - 1], window);
            }

            int[] dp = new int[len];
            dp[firstLen + secondLen - 1] = pre[firstLen + secondLen];
            for (int i = firstLen + secondLen, t; i < len; i++)
            {
                t = pre[i + 1] - pre[i - firstLen + 1] + max2[i - firstLen];
                dp[i] = Math.Max(dp[i - 1], t);
                t = pre[i + 1] - pre[i - secondLen + 1] + max1[i - secondLen];
                dp[i] = Math.Max(dp[i], t);
            }

            return dp[len - 1];
        }

        /// <summary>
        /// 与MaxSumTwoNoOverlap2()一样，滚动数组
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="firstLen"></param>
        /// <param name="secondLen"></param>
        /// <returns></returns>
        public int MaxSumTwoNoOverlap2(int[] nums, int firstLen, int secondLen)
        {
            int len = nums.Length;
            int[] pre = new int[len + 1], max1 = new int[len], max2 = new int[len];
            for (int i = 0; i < len; i++) pre[i + 1] = pre[i] + nums[i];
            int window = nums[0..firstLen].Sum(); max1[firstLen - 1] = window;
            for (int i = firstLen; i < len; i++)
            {
                window = window - nums[i - firstLen] + nums[i];
                max1[i] = Math.Max(max1[i - 1], window);
            }
            window = nums[0..secondLen].Sum(); max2[secondLen - 1] = window;
            for (int i = secondLen; i < len; i++)
            {
                window = window - nums[i - secondLen] + nums[i];
                max2[i] = Math.Max(max2[i - 1], window);
            }

            int result = pre[firstLen + secondLen];
            for (int i = firstLen + secondLen, t; i < len; i++)
            {
                t = pre[i + 1] - pre[i - firstLen + 1] + max2[i - firstLen];
                result = Math.Max(result, t);
                t = pre[i + 1] - pre[i - secondLen + 1] + max1[i - secondLen];
                result = Math.Max(result, t);
            }

            return result;
        }
    }
}
