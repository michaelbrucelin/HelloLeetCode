using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2419
{
    public class Solution2419 : Interface2419
    {
        /// <summary>
        /// 遍历
        /// 找出数组最大值的最长连续的数量即可
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int LongestSubarray(int[] nums)
        {
            if (nums.Length < 2) return nums.Length;
            int result = 0, max = -1, cnt = 1, len = nums.Length;
            for (int i = 1; i < len; i++)
            {
                if (nums[i] == nums[i - 1]) { cnt++; continue; }
                if (nums[i - 1] > max)
                {
                    max = nums[i - 1]; result = cnt;
                }
                else if (nums[i - 1] == max)
                {
                    result = Math.Max(result, cnt);
                }
                cnt = 1;
            }
            if (nums[^1] > max)
            {
                result = cnt;
            }
            else if (nums[^1] == max)
            {
                result = Math.Max(result, cnt);
            }

            return result;
        }
    }
}
