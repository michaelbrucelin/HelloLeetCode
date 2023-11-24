using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2824
{
    public class Solution2824_3 : Interface2824
    {
        /// <summary>
        /// 排序 + 双指针
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int CountPairs(IList<int> nums, int target)
        {
            nums = nums.OrderBy(x => x).ToList();
            int result = 0, left = 0, right = nums.Count - 1;
            while (left < right)
            {
                while (right > left && nums[left] + nums[right] >= target) right--;
                if (right <= left) break;
                result += right - left;
                left++;
            }

            return result;
        }
    }
}
