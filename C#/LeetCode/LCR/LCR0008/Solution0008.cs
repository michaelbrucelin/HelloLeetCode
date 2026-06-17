using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0008
{
    public class Solution0008 : Interface0008
    {
        /// <summary>
        /// 双指针，滑动窗口
        /// </summary>
        /// <param name="target"></param>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MinSubArrayLen(int target, int[] nums)
        {
            if (nums[0] >= target) return 1;

            int result = nums.Length + 1, sum = 0, pl = 0, pr = 0, len = nums.Length;
            while (pl < len)
            {
                while (sum < target && pr < len) { sum += nums[pr]; pr++; }
                if (sum < target) break;
                if (pr == pl) return 1;
                result = Math.Min(result, pr - pl);
                sum -= nums[pl++];
            }

            return result != len + 1 ? result : 0;
        }
    }
}
