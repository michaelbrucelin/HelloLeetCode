using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2970
{
    public class Solution2970 : Interface2970
    {
        /// <summary>
        /// 数学，排列组合
        /// 1. 可以移除后为空，但是不可以移除空
        /// 2. 找出单调递增前缀子数组，单调递增后缀子数组，那么中间部分一定需要全部移除
        ///     [1, 2, 3, -1, 100, 6, 7, 8]
        ///     单调递增前缀子数组：[1, 2, 3]
        ///     单调递增后缀子数组：[6, 7, 8]
        ///     中间的[-1, 100]一定需要移除
        /// 3. 然后分析两边的单调递增数组的可移除的可能性
        ///     用双指针分析，当然也可以二分来解决，在这道题的限定下，二分没有太大意义，甚至会逆优化
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int IncremovableSubarrayCount(int[] nums)
        {
            int len = nums.Length;
            int len1 = 1;  // 前缀数组的长度
            while (len1 < len && nums[len1] > nums[len1 - 1]) len1++;
            if (len1 == len) return (len + 1) * len >> 1;

            int len2 = 1;  // 后缀数组的长度
            while (len2 < len && nums[len - len2 - 1] < nums[len - len2]) len2++;

            int result = 0;
            int p1 = len1 - 1, p2 = len - 1;
            while (p1 >= 0)
            {
                while (len - p2 <= len2 && nums[p2] > nums[p1]) p2--;
                result += len - p2;
                p1--;
            }
            result += len2 + 1;  // 前缀数组全部删除

            return result;
        }
    }
}
