using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1512
{
    public class Solution1512 : Interface1512
    {
        /// <summary>
        /// 暴力枚举
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int NumIdenticalPairs(int[] nums)
        {
            int result = 0, len = nums.Length;
            for (int i = 0; i < len - 1; i++) for (int j = i + 1; j < len; j++)
                {
                    if (nums[i] == nums[j]) result++;
                }

            return result;
        }
    }
}
