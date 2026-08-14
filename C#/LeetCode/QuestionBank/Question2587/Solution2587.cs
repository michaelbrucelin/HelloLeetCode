using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2587
{
    public class Solution2587 : Interface2587
    {
        /// <summary>
        /// 贪心 + 排序
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MaxScore(int[] nums)
        {
            Array.Sort(nums);
            if (nums[^1] <= 0) return 0;

            int result = 0; long sum = 0;
            for (int i = nums.Length - 1; i >= 0; i--)
            {
                if ((sum += nums[i]) > 0) result++; else break;
            }

            return result;
        }
    }
}
