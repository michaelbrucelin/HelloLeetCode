using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3541
{
    public class Solution3541 : Interface3541
    {
        /// <summary>
        /// 计数
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int MaxFreqSum(string s)
        {
            int[] freq = new int[26];
            foreach (char c in s) freq[c - 'a']++;
            int[] map = new int[26];
            map['a' - 'a'] = 1;
            map['e' - 'a'] = 1;
            map['i' - 'a'] = 1;
            map['o' - 'a'] = 1;
            map['u' - 'a'] = 1;

            int[] max = new int[2];
            for (int i = 0; i < 26; i++) max[map[i]] = Math.Max(max[map[i]], freq[i]);

            return max[0] + max[1];
        }
    }
}
