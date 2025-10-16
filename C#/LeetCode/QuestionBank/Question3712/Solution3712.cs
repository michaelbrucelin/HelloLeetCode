using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3712
{
    public class Solution3712 : Interface3712
    {
        /// <summary>
        /// 遍历
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int SumDivisibleByK(int[] nums, int k)
        {
            int result = 0;
            int[] freq = new int[101];
            foreach (int num in nums) freq[num]++;
            for (int i = 1; i < 101; i++) if (freq[i] % k == 0) result += i * freq[i];

            return result;
        }
    }
}
