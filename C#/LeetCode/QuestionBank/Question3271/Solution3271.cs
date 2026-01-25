using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3271
{
    public class Solution3271 : Interface3271
    {
        public string StringHash(string s, int k)
        {
            int len = s.Length / k;
            char[] buffer = new char[len];
            int ptr = 0, hash, idx = -1;
            while (++idx < len)
            {
                hash = 0;
                for (int i = 0; i < k; i++) hash += s[ptr++] - 'a';
                hash %= 26;
                buffer[idx] = (char)('a' + hash);
            }

            return new string(buffer);
        }
    }
}
