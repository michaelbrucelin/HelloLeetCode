using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1796
{
    public class Solution1796_2 : Interface1796
    {
        public int SecondHighest(string s)
        {
            int mask = 0;
            for (int i = 0; i < s.Length; i++)
                if (char.IsDigit(s[i])) mask |= (1 << (s[i] - '0'));

            for (int i = 9, id = 0; i >= 0; i--)
                if ((mask & (1 << i)) != 0 && ++id == 2) return i;

            return -1;
        }
    }
}
