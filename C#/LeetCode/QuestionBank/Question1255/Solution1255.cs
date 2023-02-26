using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1255
{
    public class Solution1255 : Interface1255
    {
        /// <summary>
        /// 递归
        /// 1. 将letters整理为词频（每个字符的数量），相当于总的资源
        /// 2. 将words中的每个word整理为词频与得分，相当于消耗相应的资源可以得到多少报酬
        /// 这样就变成“金矿”问题了，可以使用递归、记忆化搜索与DP至少3种方式求解
        /// 
        /// 这里先用递归求解一下，提交竟然能过。。。本以为会超时
        /// </summary>
        /// <param name="words"></param>
        /// <param name="letters"></param>
        /// <param name="score"></param>
        /// <returns></returns>
        public int MaxScoreWords(string[] words, char[] letters, int[] score)
        {
            // Dictionary<char, int> freq = letters.GroupBy(c => c).ToDictionary(g => g.Key, g => g.Count());
            Dictionary<char, int> freq = new Dictionary<char, int>();
            for (int i = 0; i < letters.Length; i++) if (freq.ContainsKey(letters[i])) freq[letters[i]]++; else freq.Add(letters[i], 1);

            return rec(words, 0, freq, score);
        }

        private int rec(string[] words, int id, Dictionary<char, int> letters, int[] score)
        {
            if (id >= words.Length || letters.Count == 0) return 0;

            bool flag = true;  // words[index]能不能用
            Dictionary<char, int> _letters = new Dictionary<char, int>(letters);
            string _word = words[id]; int _score = 0;
            for (int i = 0; i < _word.Length; i++)
            {
                char c = _word[i];
                if (!_letters.ContainsKey(c)) { flag = false; break; }
                _score += score[c - 'a']; _letters[c]--; if (_letters[c] == 0) _letters.Remove(c);
            }

            if (flag)
                return Math.Max(_score + rec(words, id + 1, _letters, score), rec(words, id + 1, new Dictionary<char, int>(letters), score));
            else
                return rec(words, id + 1, new Dictionary<char, int>(letters), score);
        }
    }
}
