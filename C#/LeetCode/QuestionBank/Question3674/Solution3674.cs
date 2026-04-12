using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3674
{
    public class Solution3674 : Interface3674
    {
        /// <summary>
        /// 脑筋急转弯
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MinOperations(int[] nums)
        {
            int x = nums[0], len = nums.Length;
            for (int i = 1; i < len; i++) if (nums[i] != x) return 1;

            return 0;
        }
    }
}
