using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3442
{
    public class Solution3442 : Interface3442
    {
        /// <summary>
        /// 计数
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int MaxDifference(string s)
        {
            int[] freq = new int[26];
            foreach (char c in s) freq[c - 'a']++;
            int[] a = [int.MaxValue, int.MinValue];
            foreach (int x in freq) if (x != 0)
                {
                    a[x & 1] = ((x & 1) ^ 1) * Math.Min(a[x & 1], x) + (x & 1) * Math.Max(a[x & 1], x);
                }

            return a[1] - a[0];
        }
    }
}
