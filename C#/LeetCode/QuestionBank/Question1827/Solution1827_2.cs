using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1827
{
    public class Solution1827_2 : Interface1827
    {
        /// <summary>
        /// 不改变原数组
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MinOperations(int[] nums)
        {
            if (nums.Length == 1) return 0;

            int result = 0, should = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                should++;
                if (should < nums[i])
                    should = nums[i];
                else
                    result += should - nums[i];
            }

            return result;
        }
    }
}
