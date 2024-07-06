using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3101
{
    public class Solution3101 : Interface3101
    {
        /// <summary>
        /// 数学
        /// 如果一个数组是交错的，那么一共有(n+1)*n/2个交错子数组
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public long CountAlternatingSubarrays(int[] nums)
        {
            long result = 0, left = 0, right, len = nums.Length;
            while (left < len)
            {
                right = left;
                while (right + 1 < len && nums[right + 1] != nums[right]) right++;
                result += (right - left + 2) * (right - left + 1) >> 1;
                left = right + 1;
            }

            return result;
        }
    }
}
