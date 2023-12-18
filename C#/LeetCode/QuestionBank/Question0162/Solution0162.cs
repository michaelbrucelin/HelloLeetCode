using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0162
{
    public class Solution0162 : Interface0162
    {
        /// <summary>
        /// 二分法
        /// 1. 题目限定
        ///     相邻元素不等
        ///     nums[-1] = nums[n] = -∞，即数组起始是递增的，终止是递减的，所以一定存在峰值
        /// 2. 取数组中间的值，a[mid]，如果a[mid]是峰值，返回mid，如果a[mid]不是峰值
        ///     a[mid] <= a[mid-1]，那么a[0] - a[mid-1]之间必有峰值，否则a[mid+1] - a[n-1]之间必有峰值
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int FindPeakElement(int[] nums)
        {
            int len = nums.Length;
            if (len == 1 || nums[0] > nums[1]) return 0;
            if (nums[len - 1] > nums[len - 2]) return len - 1;

            int left = 1, right = len - 2, mid;
            while (left <= right)
            {
                mid = left + ((right - left) >> 1);
                if (nums[mid - 1] < nums[mid] && nums[mid] > nums[mid + 1]) return mid;
                if (nums[mid - 1] > nums[mid]) right = mid - 1; else left = mid + 1;
            }

            throw new Exception("logic error.");
        }
    }
}
