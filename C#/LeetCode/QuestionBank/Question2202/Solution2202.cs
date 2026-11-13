using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2202
{
    public class Solution2202 : Interface2202
    {
        /// <summary>
        /// 分类讨论
        /// 令nums的长度为n
        /// n = 1, k & 1 = 1 --> -1, k & 1 = 0 --> nums[0]
        /// n > 1, k = 1 --> nums[1]
        /// n > 1, 1 < k = n, nums 前 k-1 项的最大值
        /// n > 1, 1 < k < n, MAX(nums 前 k-1 项的最大值, nums[k])
        ///        k > len, nums 的最大值
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int MaximumTop(int[] nums, int k)
        {
            int len = nums.Length;
            if (len == 0) return -1;
            if (len == 1) return (k & 1) == 1 ? -1 : nums[0];
            if (k == 1) return nums[1];

            int result = nums[0];
            if (k == len)
            {
                for (int i = 1; i < k - 1; i++) result = Math.Max(result, nums[i]);
            }
            else if (k < len)
            {
                for (int i = 1; i < k - 1; i++) result = Math.Max(result, nums[i]);
                result = Math.Max(result, nums[k]);
            }
            else
            {
                for (int i = 1; i < len; i++) result = Math.Max(result, nums[i]);
            }

            return result;
        }
    }
}
