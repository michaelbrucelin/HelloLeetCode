using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2027
{
    public class Solution2027 : Interface2027
    {
        public int MinimumMoves(string s)
        {
            int result = 0;
            int ptr = 0, len = s.Length;
            while (ptr < len)
            {
                if (s[ptr] == 'X')
                {
                    result++; ptr += 3;
                }
                else
                {
                    ptr++;
                }
            }

            return result;
        }
    }
}
