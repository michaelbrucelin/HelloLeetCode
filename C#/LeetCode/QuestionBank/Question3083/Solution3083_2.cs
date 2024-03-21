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
    }
}
