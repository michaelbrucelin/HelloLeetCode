using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2824
{
    public class Solution2824_2 : Interface2824
    {
        /// <summary>
        /// 排序 + 二分
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int CountPairs(IList<int> nums, int target)
        {
            nums = nums.OrderBy(x => x).ToList();
            int result = 0, cnt = nums.Count;
            for (int i = 0, right = cnt - 1; i < cnt; i++)
            {
                right = BinarySearch(nums, i + 1, right, target - nums[i]);
                if (right == -1) break;
                result += right - i;
            }

            return result;
        }

        private int BinarySearch(IList<int> nums, int left, int right, int target)
        {
            int result = -1, mid;
            while (left <= right)
            {
                mid = left + ((right - left) >> 1);
                if (nums[mid] < target)
                {
                    result = mid; left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }

            return result;
        }
    }
}
