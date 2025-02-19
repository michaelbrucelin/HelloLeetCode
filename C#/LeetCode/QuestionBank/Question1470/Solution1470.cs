using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1470
{
    public class Solution1470 : Interface1470
    {
        /// <summary>
        /// 映射
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public int[] Shuffle(int[] nums, int n)
        {
            int[] result = new int[nums.Length];

            for (int i = 0; i < n; i++)
            {
                result[i * 2] = nums[i];
                result[i * 2 + 1] = nums[n + i];
            }

            return result;
        }
    }
}
