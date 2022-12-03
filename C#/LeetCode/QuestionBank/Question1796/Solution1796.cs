using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1796
{
    public class Solution1796 : Interface1796
    {
        public int SecondHighest(string s)
        {
            int first = -1, second = -1;
            for (int i = 0; i < s.Length; i++)
            {
                if (!char.IsDigit(s[i])) continue;
                int v = s[i] - '0';
                if (v > first) { second = first; first = v; continue; }
                if (v < first && v > second) second = v;
            }

            return second;
        }
    }
}
