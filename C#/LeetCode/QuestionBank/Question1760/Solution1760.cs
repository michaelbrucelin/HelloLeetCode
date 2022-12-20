using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1760
{
    public class Solution1760 : Interface1760
    {
        /// <summary>
        /// 贪心法
        /// 具体见Solution1760.md
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="maxOperations"></param>
        /// <returns></returns>
        public int MinimumSize(int[] nums, int maxOperations)
        {
            Array.Sort(nums, (i1, i2) => i2.CompareTo(i1));
            int len = nums.Length, sum = 0, right = nums[0];
            for (int i = 0; i < len; i++) sum += nums[i];
            int left = (int)Math.Ceiling((double)sum / (len + maxOperations));

            int result = right;
            while (left <= right)
            {
                int mid = left + ((right - left) >> 1);
                int steps = 0;
                for (int i = 0; i < len; i++)
                {
                    if (nums[i] > mid) steps += (nums[i] - 1) / mid; else break;
                }
                if (steps <= maxOperations) { result = mid; right = mid - 1; } else left = mid + 1;
            }

            return result;
        }
    }
}
