using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0720
{
    public class Solution0720 : Interface0720
    {
        /// <summary>
        /// 贪心，类BFS
        /// 将words按长度分组，一层一层查找即可
        /// </summary>
        /// <param name="words"></param>
        /// <returns></returns>
        public string LongestWord(string[] words)
        {
            if (words.Length == 0) return "";
            List<string>[] _words = new List<string>[31];  // 题目限定word.Length <= 30
            for (int i = 0; i < 31; i++) _words[i] = [];
            foreach (string word in words) _words[word.Length].Add(word);
            if (_words[1].Count == 0) return "";

            string result = _words[1][0];
            HashSet<string> set = new HashSet<string>();
            foreach (string word in _words[1])
            {
                if (string.CompareOrdinal(word, result) < 0) result = word;
                set.Add(word);
            }

            for (int i = 2; i < 31 && i == result.Length + 1; i++) foreach (string word in _words[i])
                {
                    if (set.Contains(word[..^1]))
                    {
                        set.Add(word);
                        if (word.Length > result.Length || string.CompareOrdinal(word, result) < 0) result = word;
                    }
                }

            return result;
        }
    }
}
