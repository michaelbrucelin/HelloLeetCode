using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0214
{
    public class Solution0214 : Interface0214
    {
        /// <summary>
        /// 字符串Hash
        /// 找出s的最长回文前缀即可
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string ShortestPalindrome(string s)
        {
            if (s.Length < 2) return s;
            if (s.Length == 2) return s[0] != s[1] ? $"{s[1]}{s}" : s;

            int len = s.Length;
            const int MOD = (int)1e9 + 7, BASE = 31, ORI = '`';
            long hash1 = s[0] - ORI, hash2 = s[0] - ORI, _base = BASE;
            int ptr = 0, maxptr = 0;
            while (++ptr < len)
            {
                hash1 = (hash1 * BASE + s[ptr] - ORI) % MOD;
                hash2 = ((s[ptr] - ORI) * _base + hash2) % MOD;
                if (hash1 == hash2)
                {
                    for (int i = 0, j = ptr; i < j; i++, j--) if (s[i] != s[j]) goto CONTINUE;
                    maxptr = ptr;
                CONTINUE:;
                }
                _base = _base * BASE % MOD;
            }

            char[] pres = new char[len - maxptr - 1];
            for (int i = 0, j = len - 1; j > maxptr; i++, j--) pres[i] = s[j];
            return $"{new string(pres)}{s}";
        }
    }
}
