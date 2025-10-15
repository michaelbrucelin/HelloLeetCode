using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3688
{
    public class Solution3688 : Interface3688
    {
        /// <summary>
        /// 遍历
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int EvenNumberBitwiseORs(int[] nums)
        {
            int result = 0, len = nums.Length;
            for (int i = 0; i < len; i++) if ((nums[i] & 1) == 0) result |= nums[i];

            return result;
        }
    }
}
