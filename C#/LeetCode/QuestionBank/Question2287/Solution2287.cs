using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2287
{
    public class Solution2287 : Interface2287
    {
        public int RearrangeCharacters2(string s, string target)
        {
            if (s.Length < target.Length) return 0;

            int[] freq_s = new int[26];
            int[] freq_t = new int[26];
            for (int i = 0; i < s.Length; i++) freq_s[s[i] - 'a']++;
            for (int i = 0; i < target.Length; i++) freq_t[target[i] - 'a']++;

            int result = int.MaxValue;
            for (int i = 0; i < 26; i++)
            {
                if (freq_t[i] != 0)
                {
                    if (freq_s[i] == 0) return 0;
                    result = Math.Min(result, freq_s[i] / freq_t[i]);
                }
            }

            return result == int.MaxValue ? 0 : result;
        }

        /// <summary>
        /// 使用API
        /// </summary>
        /// <param name="s"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int RearrangeCharacters(string s, string target)
        {
            if (s.Length < target.Length) return 0;

            Dictionary<char, int> freq_s = new Dictionary<char, int>(s.GroupBy(c => c).Select(g => new KeyValuePair<char, int>(g.Key, g.Count())));
            Dictionary<char, int> freq_t = new Dictionary<char, int>(target.GroupBy(c => c).Select(g => new KeyValuePair<char, int>(g.Key, g.Count())));

            int result = int.MaxValue;
            foreach (var kv in freq_t)
                if (!freq_s.ContainsKey(kv.Key)) return 0; else result = Math.Min(result, freq_s[kv.Key] / kv.Value);

            return result == int.MaxValue ? 0 : result;
        }

        /// <summary>
        /// 不必保留原始的顺序，所以这个解法是错的
        /// 例如：s="rav", target="vr"，结果是1，但是按照下面的解法，结果是0
        /// </summary>
        /// <param name="s"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int RearrangeCharacters3(string s, string target)
        {
            if (s.Length < target.Length) return 0;

            int result = 0;
            int ptr1 = -1, len1 = s.Length, ptr2 = 0, len2 = target.Length;
            while (++ptr1 < len1)
            {
                if (s[ptr1] == target[ptr2])
                {
                    if (++ptr2 == len2)
                    {
                        result++; ptr2 = 0;
                    }
                }
            }

            return result;
        }
    }
}
