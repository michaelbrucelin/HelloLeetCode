using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0524
{
    public class Solution0524_3 : Interface0524
    {
        /// <summary>
        /// DP
        /// 核心逻辑仍然同Solution0524，Solution0524_2采用二分法快速查找下一个字符，这里是同DP直接预处理出下一个字符的位置
        /// </summary>
        /// <param name="s"></param>
        /// <param name="dictionary"></param>
        /// <returns></returns>
        public string FindLongestWord(string s, IList<string> dictionary)
        {
            int len = s.Length;
            int[,] dp = new int[len, 26];
            for (int i = 0; i < 26; i++) dp[len - 1, i] = len; dp[len - 1, s[^1] - 'a'] = len - 1;
            for (int i = len - 2; i >= 0; i--)
            {
                for (int j = 0; j < 26; j++) dp[i, j] = dp[i + 1, j]; dp[i, s[i] - 'a'] = i;
            }

            string result = "";
            foreach (string word in dictionary) if (word.Length <= len && word.Length >= result.Length && check(word))
                {
                    // if (word.Length > result.Length || (word.Length == result.Length && string.CompareOrdinal(word, result) < 0)) result = word;
                    if (word.Length > result.Length || string.CompareOrdinal(word, result) < 0) result = word;
                }

            return result;

            bool check(string str)
            {
                int idx = 0;
                foreach (char c in str)
                {
                    if (idx >= len) return false;
                    idx = dp[idx, c - 'a'] + 1;
                }
                if (idx > len) return false;

                return true;
            }
        }
    }
}
