using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3833
{
    public class Solution3833 : Interface3833
    {
        /// <summary>
        /// 遍历
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int DominantIndices(int[] nums)
        {
            int result = 0, sum = 0;
            for (int i = nums.Length - 2, j = 1; i >= 0; i--, j++)
            {
                sum += nums[i + 1];
                if (nums[i] * j > sum) result++;
            }

            return result;
        }
    }
}
