using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1170
{
    public class Solution1170 : Interface1170
    {
        /// <summary>
        /// 预处理
        /// 预处理words数组，整理出每一个word的“最低词频”，然后类似于前缀和的思路，预处理为大于等于该词频的数组
        /// </summary>
        /// <param name="queries"></param>
        /// <param name="words"></param>
        /// <returns></returns>
        public int[] NumSmallerByFrequency(string[] queries, string[] words)
        {
            int[] freq = new int[11];
            for (int i = 0; i < words.Length; i++) freq[f(words[i]) - 1]++;
            for (int i = 8; i >= 0; i--) freq[i] += freq[i + 1];

            int[] result = new int[queries.Length];
            for (int i = 0; i < result.Length; i++) result[i] = freq[f(queries[i])];
            return result;
        }

        private int f(string s)
        {
            int[] freq = new int[26];
            for (int i = 0; i < s.Length; i++) freq[s[i] - 'a']++;
            for (int i = 0; i < 26; i++) if (freq[i] > 0) return freq[i];
            return -1;
        }
    }
}
