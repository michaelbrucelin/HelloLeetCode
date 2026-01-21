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
        /// s的长度是偶数，前面添加一个字符后，前面一半的hash需要去掉尾部字符添加头部字符，后面一半的hash不变
        /// s的长度是奇数，前面添加一个字符后，前面一半的hash需要添加头部字符，后面一半的hash需要添加头部字符
        /// 
        /// 怎样贪心的添加字符？可以二分吗？
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string ShortestPalindrome(string s)
        {
            int len = s.Length;
            for (int i = 0, j = (len + 1) >> 1; j < len; i++, j++) if (s[i] != s[j]) goto CONTINUE;
            return s;
        CONTINUE:;

            const int MOD = (int)1e9 + 7, BASE = 31; const char HEAD = '`';
            StringBuilder buffer = new StringBuilder();
            for (int i = 0; i < len; i++) buffer.Append(s[i]);
            long hashl = 0, hashr = 0, b = 1;
            for (int i = (len >> 1) - 1, j = len - 1; i >= 0; i--, j--, b = b * BASE % MOD)
            {
                hashl = ((buffer[i] - HEAD) * b + hashl) % MOD;
                hashr = ((buffer[j] - HEAD) * b + hashr) % MOD;
            }

            bool odd = (len & 1) == 1; int ptr = (len - 1) >> 1;
            while (true)  // 必有解，最多len次
            {
                buffer.Insert(0, s[ptr]);
                if (odd)
                {
                    hashl = ((s[ptr] - HEAD) * b + hashl) % MOD;
                }
                else
                {

                }
                odd = !odd; ptr--; b = b * BASE % MOD;
            }

            return buffer.ToString();

            bool check()
            {
                int cnt = buffer.Length;
                for (int i = 0, j = (cnt + 1) >> 1; j < cnt; i++, j++) if (buffer[i] != buffer[j]) return false;
                return true;
            }
        }
    }
}
