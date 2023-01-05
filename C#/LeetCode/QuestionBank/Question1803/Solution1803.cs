using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1803
{
    public class Solution1803 : Interface1803
    {
        /// <summary>
        /// 暴力解
        /// 果然会超时
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="low"></param>
        /// <param name="high"></param>
        /// <returns></returns>
        public int CountPairs(int[] nums, int low, int high)
        {
            int result = 0;
            int len = nums.Length;
            for (int i = 0; i < len - 1; i++) for (int j = i + 1; j < len; j++)
                {
                    int xor = nums[i] ^ nums[j];
                    if (xor >= low && xor <= high) result++;
                }

            return result;
        }
    }
}
