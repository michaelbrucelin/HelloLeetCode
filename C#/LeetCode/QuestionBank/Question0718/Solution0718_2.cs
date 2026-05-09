using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0718
{
    public class Solution0718_2 : Interface0718
    {
        /// <summary>
        /// DP
        /// 令F(x,y)表示以nums1[x]与nums2[y]结尾的最长子数组的长度，则
        ///     F(x+1,y+1) = nums1[x+1] == nums2[y+1] ? F(x,y)+1 : 0
        /// 然后找出所有F(x,y)的最大值即可
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="nums2"></param>
        /// <returns></returns>
        public int FindLength(int[] nums1, int[] nums2)
        {
            int len1 = nums1.Length, len2 = nums2.Length;
            int[,] dp = new int[len1 + 1, len2 + 1];
            for (int i = 0; i < len1; i++) for (int j = 0; j < len2; j++) if (nums1[i] == nums2[j])
                    {
                        dp[i + 1, j + 1] = dp[i, j] + 1;
                    }

            int result = 0;
            for (int i = 1; i <= len1; i++) for (int j = 1; j <= len2; j++)
                {
                    result = Math.Max(result, dp[i, j]);
                }

            return result;
        }

        /// <summary>
        /// 逻辑同FindLength()，略加优化
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="nums2"></param>
        /// <returns></returns>
        public int FindLength2(int[] nums1, int[] nums2)
        {
            int result = 0, len1 = nums1.Length, len2 = nums2.Length;
            int[,] dp = new int[len1 + 1, len2 + 1];
            for (int i = 0; i < len1; i++) for (int j = 0; j < len2; j++) if (nums1[i] == nums2[j])
                    {
                        dp[i + 1, j + 1] = dp[i, j] + 1;
                        result = Math.Max(result, dp[i + 1, j + 1]);
                    }

            return result;
        }
    }
}
