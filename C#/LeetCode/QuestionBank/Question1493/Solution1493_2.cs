using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1493
{
    public class Solution1493_2 : Interface1493
    {
        /// <summary>
        /// 滑动窗口，双指针
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int LongestSubarray(int[] nums)
        {
            int result = 0, pl = 0, pr = 0, cnt0 = 0, len = nums.Length;
            while (true)
            {
                while (cnt0 < 2 && pr < len) cnt0 += 1 - nums[pr++];
                result = cnt0 < 2 ? Math.Max(result, pr - pl - 1) : Math.Max(result, pr - pl - 2);
                if (pr == len) break;
                while (cnt0 > 1) cnt0 -= 1 - nums[pl++];
            }

            return result;
        }
    }
}
