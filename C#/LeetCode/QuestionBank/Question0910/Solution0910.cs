using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0910
{
    public class Solution0910 : Interface0910
    {
        /// <summary>
        /// 遍历
        /// 总结，x < y, y - x，O(n^2)
        ///     > 2k, y-x-2k
        ///     = 2k, 0
        ///     > k,  2k-y+x
        ///     <= k, k
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int SmallestRangeII(int[] nums, int k)
        {
            if (k == 0 || nums.Length == 1) return 0;

            int result = int.MaxValue, min = nums[0] - k, max = nums[0] + k, len = nums.Length;
            for (int i = 1, _min = 0, _max = 0; i < len; i++)
            {
            }

            return result;
        }
    }
}
