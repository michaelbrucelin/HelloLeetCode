using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1255
{
    public class Solution1255_4 : Interface1255
    {
        public int MaxScoreWords(string[] words, char[] letters, int[] score)
        {
            int result = 0, len = words.Length;
            int[] freq = new int[26];
            for (int i = 0; i < letters.Length; i++) freq[letters[i] - 'a']++;
            int[] scores = new int[len];
            for (int i = 0; i < len; i++) for (int j = 0; j < words[i].Length; j++) scores[i] += score[words[i][j] - 'a'];


            for (int s = 1; s < (1 << len); s++)
            {
                int _score = 0;
                int[] _freq = new int[26];
                for (int i = 0; i < len; i++)  // 题目中每个word长度<=15，即<26，所以没必要预处理每个word的字符频率
                {
                    if (((s >> i) & 1) != 1) continue;
                    for (int j = 0; j < words[i].Length; j++) _freq[words[i][j] - 'a']++;
                    _score += scores[i];
                }

                bool ok = true;
                for (int i = 0; i < 26; i++) if (_freq[i] > freq[i]) { ok = false; break; }

                if (ok) result = Math.Max(result, _score);
            }

            return result;
        }
    }
}
