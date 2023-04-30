using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Interview.Interview0102
{
    public class Solution0102 : Interface0102
    {
        /// <summary>
        /// 检查两个字符串中字符的词频
        /// </summary>
        /// <param name="s1"></param>
        /// <param name="s2"></param>
        /// <returns></returns>
        public bool CheckPermutation(string s1, string s2)
        {
            if (s1.Length != s2.Length) return false;

            Dictionary<char, int> freq = new Dictionary<char, int>();
            for (int i = 0; i < s1.Length; i++)
            {
                if (freq.ContainsKey(s1[i])) freq[s1[i]]++;
                else freq.Add(s1[i], 1);
            }

            for (int i = 0; i < s2.Length; i++)
            {
                if (!freq.ContainsKey(s2[i])) return false;
                if (freq[s2[i]] > 1) freq[s2[i]]--; else freq.Remove(s2[i]);
            }

            return true;
        }

        /// <summary>
        /// 验证排序后是否相等
        /// </summary>
        /// <param name="s1"></param>
        /// <param name="s2"></param>
        /// <returns></returns>
        public bool CheckPermutation2(string s1, string s2)
        {
            if (s1.Length != s2.Length) return false;

            return Enumerable.SequenceEqual(s1.OrderBy(c => c), s2.OrderBy(c => c));
        }
    }
}
