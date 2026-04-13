using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3692
{
    public class Solution3692 : Interface3692
    {
        /// <summary>
        /// 枚举
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string MajorityFrequencyGroup(string s)
        {
            int[] freq = new int[26];
            foreach (char c in s) freq[c - 'a']++;
            Dictionary<int, List<char>> map = new Dictionary<int, List<char>>();
            for (int i = 0; i < 26; i++) if (freq[i] > 0)
                {
                    if (map.TryGetValue(freq[i], out List<char> chars)) chars.Add((char)(i + 'a')); else map.Add(freq[i], [(char)(i + 'a')]);
                }

            int k = 0; List<char> result = [];
            foreach (int key in map.Keys)
            {
                if (map[key].Count > result.Count || (map[key].Count == result.Count && key > k)) { result = map[key]; k = key; }
            }

            return new string([.. result]);
        }
    }
}
