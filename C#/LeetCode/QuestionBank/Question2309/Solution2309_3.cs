using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2309
{
    public class Solution2309_3 : Interface2309
    {
        public string GreatestLetter(string s)
        {
            int lower = 0, upper = 0;
            for (int i = 0; i < s.Length; i++)
                if (char.IsLower(s[i])) lower |= 1 << (s[i] - 'a'); else upper |= 1 << (s[i] - 'A');

            for (int i = 25; i >= 0; i--)
                if ((((lower >> i) & 1) == 1) && ((upper >> i) & 1) == 1) return ((char)(65 + i)).ToString();

            return string.Empty;
        }

        /// <summary>
        /// 与GreatestLetter()逻辑一样，把两个mask整型合并为一个long
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string GreatestLetter2(string s)
        {
            long mask = 0;
            for (int i = 0; i < s.Length; i++)
                if (char.IsLower(s[i])) mask |= 1 << (s[i] - 'a'); else mask |= 1 << (s[i] - 'A' + 26);

            for (int i = 25; i >= 0; i--)
                if ((((mask >> i) & 1) == 1) && ((mask >> i + 26) & 1) == 1) return ((char)(65 + i)).ToString();

            return string.Empty;
        }
    }
}
