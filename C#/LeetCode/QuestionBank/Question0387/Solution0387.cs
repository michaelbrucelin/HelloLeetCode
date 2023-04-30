using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0387
{
    public class Solution0387 : Interface0387
    {
        public int FirstUniqChar(string s)
        {
            int[,] buffer = new int[2, 26];  // 第一维：次数，第二维：索引
            int len = s.Length, maybe = 26;
            for (int i = 0; i < len; i++)
            {
                int id = s[i] - 'a';
                if (++buffer[0, id] == 2) maybe--;
                buffer[1, id] = i;

                if (maybe == 0) return -1;
            }

            int result = len + 1;
            for (int i = 0; i < 26; i++) if (buffer[0, i] == 1 && buffer[1, i] < result) result = buffer[1, i];

            return result != len + 1 ? result : -1;
        }

        /// <summary>
        /// API
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int FirstUniqChar2(string s)
        {
            Dictionary<char, int> freqs = s.GroupBy(c => c).ToDictionary(g => g.Key, g => g.Count());
            Dictionary<char, int> first = s.Select((c, i) => (c, i)).GroupBy(item => item.c).ToDictionary(g => g.Key, g => g.First().i);

            int result = s.Length + 1;
            foreach (var kv in freqs)
            {
                if (kv.Value == 1 && first[kv.Key] < result) result = first[kv.Key];
            }

            return result != s.Length + 1 ? result : -1;
        }
    }
}
