using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3016
{
    public class Solution3016 : Interface3016
    {
        /// <summary>
        /// 贪心
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public int MinimumPushes(string word)
        {
            int[] freq = new int[26];
            foreach (char c in word) freq[c - 'a']++;
            Array.Sort(freq);

            int result = 0;
            for (int i = 25, j = 8; i >= 0 && freq[i] > 0; i--, j++) result += freq[i] * (j / 8);

            return result;
        }
    }
}
