using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1255
{
    public class Solution1255_2 : Interface1255
    {
        /// <summary>
        /// 记忆化搜索
        /// 1. 将letters整理为词频（每个字符的数量），相当于总的资源
        /// 2. 将words中的每个word整理为词频与得分，相当于消耗相应的资源可以得到多少报酬
        /// 这样就变成“金矿”问题了，可以使用递归、记忆化搜索与DP至少3种方式求解
        /// 
        /// 这里先用记忆化搜索求解一下，实际效果不明显，可能是重复性不高，也可能是字典转成字符串的成本导致的，没有细究具体的原因
        /// </summary>
        /// <param name="words"></param>
        /// <param name="letters"></param>
        /// <param name="score"></param>
        /// <returns></returns>
        public int MaxScoreWords(string[] words, char[] letters, int[] score)
        {
            Dictionary<(int, string), int> buffer = new Dictionary<(int, string), int>();
            // Dictionary<char, int> freq = letters.GroupBy(c => c).ToDictionary(g => g.Key, g => g.Count());
            Dictionary<char, int> freq = new Dictionary<char, int>();
            for (int i = 0; i < letters.Length; i++) if (freq.ContainsKey(letters[i])) freq[letters[i]]++; else freq.Add(letters[i], 1);

            return rec(words, 0, freq, score, buffer);
        }

        private int rec(string[] words, int id, Dictionary<char, int> letters, int[] score, Dictionary<(int, string), int> buffer)
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

            string key = string.Join(';', letters.OrderBy(kv => kv.Key).Select(kv => $"{kv.Key}:{kv.Value}"));
            if (!buffer.ContainsKey((id + 1, key)))
                buffer.Add((id + 1, key), rec(words, id + 1, new Dictionary<char, int>(letters), score, buffer));

            if (flag)
            {
                string _key = string.Join(';', _letters.OrderBy(kv => kv.Key).Select(kv => $"{kv.Key}:{kv.Value}"));
                int _point;   // int point, _point;
                if (buffer.ContainsKey((id + 1, _key))) _point = buffer[(id + 1, _key)];
                else
                {
                    _point = rec(words, id + 1, _letters, score, buffer);
                    buffer.Add((id + 1, _key), _point);
                }

                return Math.Max(_score + _point, buffer[(id + 1, key)]);
            }
            else
            {
                return buffer[(id + 1, key)];
            }
        }
    }
}
