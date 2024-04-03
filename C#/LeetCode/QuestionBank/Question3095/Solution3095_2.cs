using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3095
{
    public class Solution3095_2 : Interface3095
    {
        /// <summary>
        /// 贪心 + 暴力查找 + 记忆化
        /// 如果长度为 _len 没有找到结果，下一轮长度为 _len+1 可以利用上一轮的结果
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int MinimumSubarrayLength(int[] nums, int k)
        {
            if (k == 0) return 1;
            int len = nums.Length;
            for (int i = 0; i < len; i++) if (nums[i] >= k) return 1;

            int[] memory = nums.ToArray();
            for (int _len = 2; _len <= len; _len++) for (int i = 0; i <= len - _len; i++)
                {
                    if ((memory[i] |= nums[i + _len - 1]) >= k) return _len;
                }

            return -1;
        }
    }
}
