using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2042
{
    public class Solution2042_4 : Interface2042
    {
        public bool AreNumbersAscending(string s)
        {
            int ptr = -1, len = s.Length, cur, pre = -1;
            while (++ptr < len)
            {
                if (char.IsDigit(s[ptr]))
                {
                    cur = s[ptr] - '0';
                    while (++ptr < len && char.IsDigit(s[ptr])) cur = cur * 10 + (s[ptr] - '0');
                    if (cur <= pre) return false;
                    pre = cur;
                }
            }

            return true;
        }
    }
}
