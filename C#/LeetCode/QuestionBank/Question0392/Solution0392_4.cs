using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0392
{
    public class Solution0392_4 : Interface0392
    {
        public bool IsSubsequence(string s, string t)
        {
            int len_t = t.Length;
            int[,] dp = new int[26, len_t + 1];
            for (int i = 0; i < 26; i++) dp[i, len_t] = -1;
            for (int i = len_t - 1; i >= 0; i--) for (int j = 0, id = t[i] - 'a'; j < 26; j++)
                {
                    dp[j, i] = j != id ? dp[j, i + 1] : i;
                }

            for (int i = 0, cur = 0; i < s.Length; i++)
            {
                int next = dp[s[i] - 'a', cur];
                if (next != -1) cur = next + 1; else return false;
            }

            return true;
        }
    }
}
