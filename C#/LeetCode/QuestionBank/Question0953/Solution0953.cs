using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0953
{
    public class Solution0953 : Interface0953
    {
        public bool IsAlienSorted(string[] words, string order)
        {
            int[] map = new int[26];
            for (int i = 0; i < 26; i++) map[order[i] - 'a'] = i;  // 题目保证order长度是26
            for (int i = 1; i < words.Length; i++) if (Greater(words[i - 1], words[i], map)) return false;

            return true;
        }

        private bool Greater(string word1, string word2, int[] map)
        {
            int len1 = word1.Length, len2 = word2.Length; int len = Math.Min(len1, len2);
            int i; for (i = 0; i < len; i++)
            {
                switch (map[word1[i] - 'a'] - map[word2[i] - 'a'])
                {
                    case > 0: return true;
                    case < 0: return false;
                    default: break;
                }
            }
            if (i < len1) return true;

            return false;
        }
    }
}
