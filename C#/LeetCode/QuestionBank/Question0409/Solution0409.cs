using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0409
{
    public class Solution0409 : Interface0409
    {
        public int LongestPalindrome(string s)
        {
            if (s.Length == 1) return 1;

            int result = 0;
            bool[] buffer = new bool[58];
            for (int i = 0; i < s.Length; i++)
            {
                int id = s[i] - 'A';
                if (buffer[id]) result += 2;
                buffer[id] = !buffer[id];
            }
            for (int i = 0; i < 58; i++)
            {
                if (buffer[i])
                {
                    result++; break;
                }
            }

            return result;
        }
    }
}
