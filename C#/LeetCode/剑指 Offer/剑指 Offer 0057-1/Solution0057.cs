using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.剑指_Offer.剑指_Offer_0057_1
{
    public class Solution0057 : Interface0057
    {
        /// <summary>
        /// 二分法
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int[] TwoSum(int[] nums, int target)
        {
            int len = nums.Length;
            for (int i = 0, j; i < len; i++)
            {
                if ((j = BinarySearch(nums, i + 1, len - 1, target - nums[i])) > 0)
                    return new int[] { nums[i], nums[j] };
            }
            return null;
        }

        private int BinarySearch(int[] nums, int left, int right, int target)
        {
            int mid; while (left <= right)
            {
                mid = left + ((right - left) >> 1);
                if (nums[mid] == target) return mid;
                else if (nums[mid] < target) left = mid + 1;
                else right = mid - 1;
            }

            return -1;
        }
    }
}
