using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2997
{
    public class Solution2997 : Interface2997
    {
        /// <summary>
        /// 位运算
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int MinOperations(int[] nums, int k)
        {
            int result = 0, xor = 0, len = nums.Length;
            for (int i = 0; i < len; i++) xor ^= nums[i];
            while (k > 0 || xor > 0)
            {
                result += (k & 1) ^ (xor & 1);
                k >>= 1; xor >>= 1;
            }

            return result;
        }
    }
}
