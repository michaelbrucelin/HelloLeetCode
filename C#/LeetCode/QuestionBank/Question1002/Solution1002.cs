using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1002
{
    public class Solution1002 : Interface1002
    {
        public IList<string> CommonChars(string[] words)
        {
            int[] freq = new int[26], _freq;
            for (int i = 0; i < words[0].Length; i++) freq[words[0][i] - 'a']++;
            for (int i = 1; i < words.Length; i++)
            {
                _freq = new int[26];
                for (int j = 0; j < words[i].Length; j++)
                {
                    int id = words[i][j] - 'a';
                    if (freq[id] > 0) { _freq[id]++; freq[id]--; }
                }
                freq = _freq;
            }

            List<string> result = new List<string>();
            for (int i = 0; i < 26; i++) for (int j = 0; j < freq[i]; j++) result.Add($"{(char)('a' + i)}");
            return result;
        }

        public IList<string> CommonChars2(string[] words)
        {
            int[] freq = new int[26], _freq = new int[26];
            int len = words.Length;
            Array.Fill(freq, int.MaxValue);
            foreach (string word in words)
            {
                Array.Fill(_freq, 0);
                foreach (char c in word) _freq[c - 'a']++;
                for (int i = 0; i < 26; i++) freq[i] = Math.Min(freq[i], _freq[i]);
            }

            List<string> result = new List<string>();
            for (int i = 0; i < 26; i++) for (int j = 0; j < freq[i]; j++) result.Add($"{(char)(i + 'a')}");
            return result;
        }
    }
}
