using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0068
{
    public class Solution0068 : Interface0068
    {
        /// <summary>
        /// 二分法
        /// 找出小于等于target的最大的元素
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int SearchInsert(int[] nums, int target)
        {
            int leftid = -1, left = 0, right = nums.Length - 1, mid;
            while (left <= right)
            {
                mid = left + ((right - left) >> 1);
                if (nums[mid] == target) return mid;
                if (nums[mid] < target)
                {
                    left = mid + 1; leftid = mid;
                }
                else
                {
                    right = mid - 1;
                }
            }

            return leftid + 1;
        }
    }
}
