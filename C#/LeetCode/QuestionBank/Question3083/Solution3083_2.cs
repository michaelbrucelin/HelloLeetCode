using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3083
{
    public class Solution3083_2 : Interface3083
    {
        /// <summary>
        /// 哈希
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public bool IsSubstringPresent(string s)
        {
            bool[,] set = new bool[26, 26];
            for (int i = 1; i < s.Length; i++)
            {
                if (s[i] == s[i - 1] || set[s[i - 1] - 'a', s[i] - 'a']) return true;
                set[s[i] - 'a', s[i - 1] - 'a'] = true;
            }

            return false;
        }

        /// <summary>
        /// 逻辑同IsSubstringPresent()
        /// 由于字符串中只含有小写字母，所以可以将bool[26, 26]用一个整数表示
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public bool IsSubstringPresent2(string s)
        {
            HashSet<int> set = new HashSet<int>();
            for (int i = 1, hash; i < s.Length; i++)
            {
                if (s[i] == s[i - 1]) return true;
                hash = (1 << (s[i - 1] - 'a')) | (1 << (s[i] - 'a'));
                if (s[i] > s[i - 1]) hash *= -1;
                if (set.Contains(hash)) return true;
                set.Add(-hash);
            }

            return false;
        }
    }
}
