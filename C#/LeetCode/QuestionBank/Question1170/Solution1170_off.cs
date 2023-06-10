using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1170
{
    public class Solution1170_off : Interface1170
    {
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
            int result = 0; char c = 'z';
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == c)
                {
                    result++;
                }
                else if (s[i] < c)
                {
                    c = s[i]; result = 1;
                }
            }
            return result;
        }
    }
}
