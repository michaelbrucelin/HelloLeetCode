using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2154
{
    public class Solution2154_2 : Interface2154
    {
        /// <summary>
        /// 排序 + 二分法
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="original"></param>
        /// <returns></returns>
        public int FindFinalValue(int[] nums, int original)
        {
            Array.Sort(nums);
            int left = 0, right = nums.Length - 1;
            (bool found, int index) t;
            while ((t = BinarySearch(nums, left, right, original)).found)
            {
                original <<= 1; left = t.index + 1;
            }

            return original;
        }

        private (bool found, int index) BinarySearch(int[] nums, int left, int right, int target)
        {
            int mid;
            while (left <= right)
            {
                mid = left + ((right - left) >> 1);
                switch (nums[mid] - target)
                {
                    case < 0: left = mid + 1; break;
                    case > 0: right = mid - 1; break;
                    default: return (true, mid);
                }
            }

            return (false, -1);
        }
    }
}
