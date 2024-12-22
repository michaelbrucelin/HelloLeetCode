using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3396
{
    public class Solution3396 : Interface3396
    {
        /// <summary>
        /// Hash
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MinimumOperations(int[] nums)
        {
            int len = nums.Length, ptr = nums.Length;
            bool[] mask = new bool[101];
            while (--ptr >= 0)
            {
                if (mask[nums[ptr]]) break;
                mask[nums[ptr]] = true;
            }

            return (ptr + 3) / 3;
        }
    }
}
