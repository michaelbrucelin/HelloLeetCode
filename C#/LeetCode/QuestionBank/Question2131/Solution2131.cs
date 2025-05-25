using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2131
{
    public class Solution2131 : Interface2131
    {
        /// <summary>
        /// 贪心+ 哈希表
        /// </summary>
        /// <param name="words"></param>
        /// <returns></returns>
        public int LongestPalindrome2(string[] words)
        {
            int result = 0;
            Dictionary<string, int> map = new Dictionary<string, int>();
            string drow;
            foreach (string word in words)
            {
                if (word[0] == word[1])
                {
                    if (map.ContainsKey(word)) map[word]++; else map.Add(word, 1);
                }
                else
                {
                    drow = $"{word[1]}{word[0]}";
                    if (map.ContainsKey(drow) && map[drow] > 0)
                    {
                        result += 4; map[drow]--;
                    }
                    else
                    {
                        if (map.ContainsKey(word)) map[word]++; else map.Add(word, 1);
                    }
                }
            }

            int odd = 0;
            for (int i = 'a'; i < 'a' + 26; i++) if (map.ContainsKey(drow = $"{(char)i}{(char)i}"))
                {
                    result += (map[drow] - (map[drow] & 1)) << 1;
                    odd |= map[drow] & 1;
                }

            return result + (odd << 1);
        }

        /// <summary>
        /// 逻辑同LongestPalindrome()，将字典改为二维数组
        /// </summary>
        /// <param name="words"></param>
        /// <returns></returns>
        public int LongestPalindrome(string[] words)
        {
            int result = 0;
            int[,] freq = new int[26, 26];
            foreach (string word in words) freq[word[0] - 'a', word[1] - 'a']++;

            int odd = 0;
            for (int i = 0; i < 26; i++)
            {
                result += (freq[i, i] - (freq[i, i] & 1)) << 1;
                odd |= freq[i, i] & 1;
                for (int j = i + 1; j < 26; j++) result += Math.Min(freq[i, j], freq[j, i]) << 2;
            }

            return result + (odd << 1);
        }
    }
}
