using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2717
{
    public class Solution2717 : Interface2717
    {
        /// <summary>
        /// 数学
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int SemiOrderedPermutation(int[] nums)
        {
            int len = nums.Length, id1 = -1, idn = -1;
            for (int i = 0; i < len; i++)
            {
                if (nums[i] == 1) id1 = i; else if (nums[i] == len) idn = i;
                if (id1 != -1 && idn != -1) break;
            }

            return id1 + len - 1 - idn - (id1 < idn ? 0 : 1);
        }
    }
}
