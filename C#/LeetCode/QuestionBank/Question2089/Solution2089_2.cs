using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2089
{
    public class Solution2089_2 : Interface2089
    {
        /// <summary>
        /// 二分法
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public IList<int> TargetIndices(int[] nums, int target)
        {
            Array.Sort(nums);

            int low = -1, high = -2, left = 0, right = nums.Length - 1, mid;
            while (left <= right)
            {
                mid = left + ((right - left) >> 1);
                if (nums[mid] >= target)
                {
                    if (nums[mid] == target) low = mid;
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
            }
            if (low == -1) return new List<int>();

            left = low; right = nums.Length - 1;
            while (left <= right)
            {
                mid = left + ((right - left) >> 1);
                if (nums[mid] <= target)
                {
                    if (nums[mid] == target) high = mid;
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }

            List<int> result = new List<int>();
            for (int i = low; i <= high; i++) result.Add(i);
            return result;
        }
    }
}
