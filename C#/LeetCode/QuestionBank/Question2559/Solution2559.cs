using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2559
{
    public class Solution2559 : Interface2559
    {
        private static readonly HashSet<char> vowel = new HashSet<char>() { 'a', 'e', 'i', 'o', 'u' };

        /// <summary>
        /// 前缀和
        /// </summary>
        /// <param name="words"></param>
        /// <param name="queries"></param>
        /// <returns></returns>
        public int[] VowelStrings(string[] words, int[][] queries)
        {
            int len = words.Length;
            int[] pre = new int[len + 1];
            for (int i = 0; i < len; i++)
            {
                if (vowel.Contains(words[i][0]) && vowel.Contains(words[i][^1]))
                    pre[i + 1] = pre[i] + 1;
                else
                    pre[i + 1] = pre[i];
            }

            len = queries.Length;
            int[] result = new int[len];
            for (int i = 0; i < len; i++)
                result[i] = pre[queries[i][1] + 1] - pre[queries[i][0]];

            return result;
        }
    }
}
