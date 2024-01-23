using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3005
{
    public class Solution3005 : Interface3005
    {
        /// <summary>
        /// 两次遍历
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MaxFrequencyElements(int[] nums)
        {
            int[] freqs = new int[101];
            foreach (int num in nums) freqs[num]++;

            int max = 0, cnt = 0;
            foreach (int freq in freqs)
            {
                if (freq > max)
                {
                    max = freq; cnt = 1;
                }
                else if (freq == max)
                {
                    cnt++;
                }
            }

            return max * cnt;
        }

        /// <summary>
        /// 一次遍历
        /// 逻辑与MaxFrequencyElements()一样
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MaxFrequencyElements2(int[] nums)
        {
            int result = 0, max = 0;
            int[] freq = new int[101];
            foreach (int num in nums)
            {
                freq[num]++;
                if (freq[num] > max)
                {
                    result = max = freq[num];
                }
                else if (freq[num] == max)
                {
                    result += freq[num];
                }
            }

            return result;
        }
    }
}
