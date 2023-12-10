using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2917
{
    public class Solution2917 : Interface2917
    {
        /// <summary>
        /// 模拟
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int FindKOr(int[] nums, int k)
        {
            int result = 0, len = nums.Length;
            for (int i = 0, cnt; i < 31; i++)
            {
                cnt = 0;
                for (int j = 0; j < len; j++) cnt += (nums[j] >> i) & 1;
                if (cnt >= k) result |= 1 << i;
            }

            return result;
        }
    }
}
