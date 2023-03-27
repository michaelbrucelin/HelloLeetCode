using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1638
{
    public class Solution1638_3 : Interface1638
    {
        public int CountSubstrings(string s, string t)
        {
            int result = 0, len1 = s.Length, len2 = t.Length;
            for (int i = 0; i < len1; i++) for (int j = 0; j < len2; j++)
                {
                    for (int k = 0, diff = 0; i + k < len1 && j + k < len2; k++)
                    {
                        if (s[i + k] != t[j + k]) diff++;
                        if (diff == 1) result++; else if (diff > 1) break;
                    }
                }

            return result;
        }
    }
}
