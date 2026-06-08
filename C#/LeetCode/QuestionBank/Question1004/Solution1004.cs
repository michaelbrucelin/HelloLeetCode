using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1004
{
    public class Solution1004 : Interface1004
    {
        /// <summary>
        /// 前缀和上的双指针
        /// 如果子数组的长度为len，和为sum，如果len-sum<=k，则这个子数组满足题目要求
        /// 反过来，1 ->0, 0 -> 1，则如果子数组的长度为len，和为sum，如果sum<=k，则这个子数组满足题目要求
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int LongestOnes(int[] nums, int k)
        {
            int len = nums.Length;
            int[] sums = new int[len + 1];
            for (int i = 0; i < len; i++) sums[i + 1] = sums[i] + 1 - nums[i];

            int result = 0, p1 = 0, p2 = 0;
            while (len - p1 > result)
            {
                while (p2 < len && sums[p2 + 1] - sums[p1] <= k) p2++;
                result = Math.Max(result, p2 - p1);
                if (p2 == len) break;
                p1++;
            }

            return result;
        }
    }
}
