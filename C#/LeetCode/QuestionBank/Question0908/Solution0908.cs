using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0908
{
    public class Solution0908 : Interface0908
    {
        /// <summary>
        /// 数学
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int SmallestRangeI(int[] nums, int k)
        {
            int min = nums[0], max = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                min = Math.Min(min, nums[i]); max = Math.Max(max, nums[i]);
            }
            k <<= 1;

            return max - min <= k ? 0 : max - min - k;
        }
    }
}
