using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2716
{
    public class Solution2716 : Interface2716
    {
        /// <summary>
        /// 脑筋急转弯
        /// 就是s中不同的字符数量
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int MinimizedStringLength(string s)
        {
            int[] freq = new int[26];
            for (int i = 0; i < s.Length; i++) freq[s[i] - 'a']++;

            int result = 0;
            for (int i = 0; i < 26; i++) result += freq[i] > 0 ? 1 : 0;

            return result;
        }

        public int MinimizedStringLength2(string s)
        {
            HashSet<char> set = new HashSet<char>();
            for (int i = 0; i < s.Length; i++) set.Add(s[i]);

            return set.Count;
        }

        public int MinimizedStringLength3(string s)
        {
            int bit = 0;
            for (int i = 0; i < s.Length; i++) bit |= 1 << (s[i] - 'a');

            int result = 0;
            while (bit > 0) { result++; bit = bit & (bit - 1); }

            return result;
        }

        public int MinimizedStringLength4(string s)
        {
            return s.Distinct().Count();
        }
    }
}
