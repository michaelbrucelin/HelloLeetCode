using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2779
{
    public class Solution2779_2 : Interface2779
    {
        /// <summary>
        /// 逻辑同Solution2779，只是将二分改为了双指针
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int MaximumBeauty(int[] nums, int k)
        {
            Array.Sort(nums);
            int result = 0, len = nums.Length;
            k <<= 1;
            for (int left = 0, right = 0; left < len - result; left++)
            {
                while (right + 1 < len && nums[left] + k >= nums[right + 1]) right++;
                result = Math.Max(result, right - left + 1);
            }

            return result;
        }
    }
}
