using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2309
{
    public class Solution2309 : Interface2309
    {
        public string GreatestLetter(string s)
        {
            bool[] lower = new bool[26];
            bool[] upper = new bool[26];

            for (int i = 0; i < s.Length; i++)
                if (char.IsLower(s[i])) lower[s[i] - 'a'] = true; else upper[s[i] - 'A'] = true;

            for (int i = 25; i >= 0; i--)
                if (lower[i] && upper[i]) return ((char)(65 + i)).ToString();

            return string.Empty;
        }

        /// <summary>
        /// 与GreatestLetter()逻辑一样，把两个mask数组合并为一个
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string GreatestLetter2(string s)
        {
            int[] mask = new int[26];  // 0,初始状态；1,有小写；2,有大写；
            for (int i = 0; i < s.Length; i++)
                if (char.IsLower(s[i])) mask[s[i] - 'a'] |= 1; else mask[s[i] - 'A'] |= 2;

            for (int i = 25; i >= 0; i--)
                if (mask[i] == 3) return ((char)(65 + i)).ToString();

            return string.Empty;
        }
    }
}
