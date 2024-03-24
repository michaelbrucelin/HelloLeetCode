using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0179
{
    public class Solution0179 : Interface0179
    {
        /// <summary>
        /// 双指针
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int[] TwoSum(int[] nums, int target)
        {
            int pl = 0, pr = nums.Length - 1;
            while (pl < pr) switch (nums[pl] + nums[pr] - target)
                {
                    case 0: return new int[] { nums[pl], nums[pr] };
                    case < 0: pl++; break;
                    default: pr--; break;
                }

            return null;
        }
    }
}
