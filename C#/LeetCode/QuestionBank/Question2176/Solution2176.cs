using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2176
{
    public class Solution2176 : Interface2176
    {
        /// <summary>
        /// 暴力枚举
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int CountPairs(int[] nums, int k)
        {
            int result = 0, len = nums.Length;
            for (int i = 0; i < len - 1; i++) for (int j = i + 1; j < len; j++)
                {
                    if (nums[i] == nums[j] && i * j % k == 0) result++;
                }

            return result;
        }
    }
}
