using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3545
{
    public class Solution3545 : Interface3545
    {
        /// <summary>
        /// 计数，排序
        /// </summary>
        /// <param name="s"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int MinDeletion(string s, int k)
        {
            int[] freq = new int[26];
            foreach (char c in s) freq[c - 'a']++;
            Array.Sort(freq, (x, y) => y - x);

            int result = 0, len = s.Length;
            for (int i = k; i < len; i++) if (freq[i] > 0) result += freq[i]; else break;

            return result;
        }

        public int MinDeletion2(string s, int k)
        {
            int[] freq = new int[26];
            foreach (char c in s) freq[c - 'a']++;
            Array.Sort(freq, (x, y) => y - x);

            int result = 0, len = s.Length;
            for (int i = k; i < len; i++) result += freq[i];

            return result;
        }
    }
}
