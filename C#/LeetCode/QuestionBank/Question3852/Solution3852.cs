using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3852
{
    public class Solution3852 : Interface3852
    {
        /// <summary>
        /// 计数
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int[] MinDistinctFreqPair(int[] nums)
        {
            int len = nums.Length;
            int[] freq = new int[101];
            for (int i = 0; i < len; i++) freq[nums[i]]++;

            int[] result = new int[2];
            int p1 = 0, p2 = 0;
            while (++p1 < 101 && p2 < 2) if (freq[p1] != 0)
                {
                    if (p2 == 0)
                    {
                        result[p2++] = p1;
                    }
                    else
                    {
                        if (freq[p1] != freq[result[0]]) result[p2++] = p1;
                    }
                }
            if (p2 < 2) return [-1, -1];

            return result;
        }
    }
}
