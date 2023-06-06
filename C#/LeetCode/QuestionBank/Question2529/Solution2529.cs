using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2529
{
    public class Solution2529 : Interface2529
    {
        /// <summary>
        /// 二分法
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MaximumCount(int[] nums)
        {
            int border1 = -1, border2 = nums.Length, len = nums.Length;
            int low = 0, high = len - 1, mid;
            while (low <= high)
            {
                mid = low + ((high - low) >> 1);
                if (nums[mid] < 0) { border1 = mid; low = mid + 1; }
                else { high = mid - 1; }
            }
            low = 0; high = len - 1;
            while (low <= high)
            {
                mid = low + ((high - low) >> 1);
                if (nums[mid] > 0) { border2 = mid; high = mid - 1; }
                else { low = mid + 1; }
            }

            return Math.Max(border1 + 1, len - border2);
        }
    }
}
