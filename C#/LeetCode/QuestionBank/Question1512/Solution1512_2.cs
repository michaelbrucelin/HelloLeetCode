using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1512
{
    public class Solution1512_2 : Interface1512
    {
        /// <summary>
        /// 数学计数
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int NumIdenticalPairs(int[] nums)
        {
            int[] freq = new int[101];
            for (int i = 0; i < nums.Length; i++) freq[nums[i]]++;

            int result = 0;
            for (int i = 0; i < 101; i++) if (freq[i] > 1) result += (freq[i] * (freq[i] - 1)) >> 1;
            return result;
        }

        /// <summary>
        /// 数学计数
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int NumIdenticalPairs2(int[] nums)
        {
            int result = 0;
            int[] freq = new int[101];
            for (int i = 0; i < nums.Length; i++)
            {
                result += freq[nums[i]]; freq[nums[i]]++;
            }

            return result;
        }
    }
}
