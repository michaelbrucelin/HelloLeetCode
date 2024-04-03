using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3095
{
    public class Solution3095 : Interface3095
    {
        /// <summary>
        /// 贪心 + 暴力查找
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int MinimumSubarrayLength(int[] nums, int k)
        {
            if (k == 0) return 1;

            int len = nums.Length, orsum;
            for (int _len = 1; _len <= len; _len++) for (int i = 0; i <= len - _len; i++)
                {
                    orsum = 0;
                    for (int j = i; j < i + _len; j++) orsum |= nums[j];
                    if (orsum >= k) return _len;
                }

            return -1;
        }
    }
}
