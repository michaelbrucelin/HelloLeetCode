using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0389
{
    public class Solution0389 : Interface0389
    {
        /// <summary>
        /// 将小写字母转为数字进行异或操作
        /// </summary>
        /// <param name="s"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public char FindTheDifference(string s, string t)
        {
            if (t.Length == 1) return t[0];

            int result = 0;
            for (int i = 0; i < s.Length; i++) result ^= s[i];
            for (int i = 0; i < t.Length; i++) result ^= t[i];

            return (char)result;
        }

        public char FindTheDifference2(string s, string t)
        {
            if (t.Length == 1) return t[0];

            int[] freq = new int[26];
            for (int i = 0; i < t.Length; i++) freq[t[i] - 'a']++;
            for (int i = 0; i < s.Length; i++) freq[s[i] - 'a']--;

            for (int i = 0; i < 26; i++) if (freq[i] == 1) return (char)('a' + i);

            throw new Exception("can not be here.");
        }

        public char FindTheDifference3(string s, string t)
        {
            if (t.Length == 1) return t[0];

            int[] freq = new int[26];
            for (int i = 0; i < s.Length; i++) freq[s[i] - 'a']--;
            for (int i = 0; i < t.Length; i++)
            {
                if (++freq[t[i] - 'a'] == 1) return t[i];
            }

            // for (int i = 0; i < 26; i++) if (freq[i] == 1) return (char)('a' + i);

            throw new Exception("can not be here.");
        }

        public char FindTheDifference4(string s, string t)
        {
            if (t.Length == 1) return t[0];

            Dictionary<char, int> freq1 = s.GroupBy(c => c).ToDictionary(g => g.Key, g => g.Count());
            Dictionary<char, int> freq2 = t.GroupBy(c => c).ToDictionary(g => g.Key, g => g.Count());

            foreach (char c in freq2.Keys)
            {
                if (!freq1.ContainsKey(c) || freq2[c] == freq1[c] + 1) return c;
            }

            throw new Exception("can not be here.");
        }
    }
}
