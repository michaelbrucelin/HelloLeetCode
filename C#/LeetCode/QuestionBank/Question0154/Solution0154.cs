using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0154
{
    public class Solution0154 : Interface0154
    {
        /// <summary>
        /// 二分
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int FindMin(int[] nums)
        {
            if (nums[0] < nums[^1] || nums.Length == 1) return nums[0];

            int result = int.MaxValue, left = 0, right = nums.Length - 1, mid;
            while (left <= right && nums[left] == nums[right]) left++;
            if (left > right) return nums[0];
            while (left <= right)
            {
                mid = left + ((right - left) >> 1);
                if (nums[mid] <= nums[^1])
                {
                    result = nums[mid]; right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
            }

            return result;
        }
    }
}
