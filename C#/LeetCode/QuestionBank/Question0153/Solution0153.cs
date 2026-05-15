using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0153
{
    public class Solution0153 : Interface0153
    {
        /// <summary>
        /// 二分
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int FindMin(int[] nums)
        {
            if (nums[0] < nums[^1] || nums.Length == 1) return nums[0];

            int left = 0, right = nums.Length - 1, mid;
            while (left <= right)
            {
                mid = left + ((right - left) >> 1);
                if (nums[mid] >= nums[0]) left = mid + 1; else right = mid - 1;
            }

            return nums[left];
        }
    }
}
