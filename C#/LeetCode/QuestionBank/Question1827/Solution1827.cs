using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1827
{
    public class Solution1827 : Interface1827
    {
        /// <summary>
        /// 改变了原数组
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MinOperations(int[] nums)
        {
            if (nums.Length == 1) return 0;

            int result = 0;
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] < nums[i - 1] + 1)
                {
                    result += nums[i - 1] + 1 - nums[i];
                    nums[i] = nums[i - 1] + 1;
                }
            }

            return result;
        }
    }
}
