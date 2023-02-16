using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0500
{
    public class Solution0500 : Interface0500
    {
        private static readonly int[] map = new int[] { 2, 3, 3, 2, 1, 2, 2, 2, 1, 2, 2, 2, 3, 3, 1, 1, 1, 1, 2, 1, 1, 3, 1, 3, 1, 3 };

        public string[] FindWords(string[] words)
        {
            List<string> result = new List<string>();
            for (int i = 0; i < words.Length; i++)
            {
                bool flag = true; int line = map[(words[i][0] | 32) - 'a'];
                for (int j = 1; j < words[i].Length; j++)
                {
                    if (map[(words[i][j] | 32) - 'a'] != line) { flag = false; break; }
                }
                if (flag) result.Add(words[i]);
            }

            return result.ToArray();
        }

        private static readonly Dictionary<char, int> dic = new Dictionary<char, int> {
            {'a', 2}, {'b', 3}, {'c', 3}, {'d', 2}, {'e', 1}, {'f', 2}, {'g', 2}, {'h', 2}, {'i', 1}, {'j', 2}, {'k', 2}, {'l', 2}, {'m', 3}, {'n', 3},
            {'o', 1}, {'p', 1}, {'q', 1}, {'r', 1}, {'s', 2}, {'t', 1}, {'u', 1}, {'v', 3}, {'w', 1}, {'x', 3}, {'y', 1}, {'z', 3 },
            {'A', 2}, {'B', 3}, {'C', 3}, {'D', 2}, {'E', 1}, {'F', 2}, {'G', 2}, {'H', 2}, {'I', 1}, {'J', 2}, {'K', 2}, {'L', 2}, {'M', 3}, {'N', 3},
            {'O', 1}, {'P', 1}, {'Q', 1}, {'R', 1}, {'S', 2}, {'T', 1}, {'U', 1}, {'V', 3}, {'W', 1}, {'X', 3}, {'Y', 1}, {'Z', 3 } };

        /// <summary>
        /// 与FindWords()一样，将数组改为字典
        /// </summary>
        /// <param name="words"></param>
        /// <returns></returns>
        public string[] FindWords2(string[] words)
        {
            List<string> result = new List<string>();
            for (int i = 0; i < words.Length; i++)
            {
                bool flag = true; int line = dic[words[i][0]];
                for (int j = 1; j < words[i].Length; j++)
                {
                    if (dic[words[i][j]] != line) { flag = false; break; }
                }
                if (flag) result.Add(words[i]);
            }

            return result.ToArray();
        }
    }
}
