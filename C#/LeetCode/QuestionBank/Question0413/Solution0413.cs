using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0413
{
    public class Solution0413 : Interface0413
    {
        /// <summary>
        /// 遍历
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int NumberOfArithmeticSlices(int[] nums)
        {
            if (nums.Length < 3) return 0;
            int result = 0, cnt = 2, diff = nums[1] - nums[0], ptr = 1, len = nums.Length;
            while (++ptr < len)
            {
                if (nums[ptr] - nums[ptr - 1] != diff)
                {
                    if (cnt > 2) result += (cnt - 2) * (cnt - 1) >> 1;
                    diff = nums[ptr] - nums[ptr - 1];
                    cnt = 2;
                }
                else
                {
                    cnt++;
                }
            }
            if (cnt > 2) result += (cnt - 2) * (cnt - 1) >> 1;

            return result;
        }
    }
}
